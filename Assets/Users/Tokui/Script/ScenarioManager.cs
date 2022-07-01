using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    #region SEPARATE

    private const char SEPARATE_SUBSCENE = '#';
    private const char SEPARATE_PAGE = '&';
    private const char SEPARATE_COMMAND = '!';
    private const char SEPARATE_MAIN_START = '{';
    private const char SEPARATE_MAIN_END = '}';
    private const char OUTPUT_PARAM = '"';
    private const char OUTPUT_GLOBAL_PARAM = '$';

    #endregion

    #region COMMAND
    
    private const char COMMAND_SEPARATE_PARAM = '=';
    private const char COMMAND_SEPARATE_ANIM = '%';
    private const string COMMAND_BACKGROUND = "background";
    private const string COMMAND_FOREGROUND = "foreground";
    private const string COMMAND_CHARACTER_IMAGE = "charaimg";
    private const string COMMAND_JUMP = "jump_to";
    private const string COMMAND_SELECT = "select";
    private const string COMMAND_WAIT_TIME = "wait";
    private const string COMMAND_CHANGE_SCENE = "scene";
    private const string COMMAND_BACK_LOG = "backlog";
    private const string COMMAND_PARAM = "param";
    private const string COMMAND_GLOBAL_PARAM = "globalp";
    private const string COMMAND_BRANCH = "branch";
    private const string COMMAND_TEXT = "_text";
    private const string COMMAND_SPRITE = "_sprite";
    private const string COMMAND_COLOR = "_color";
    private const string COMMAND_SIZE = "_size";
    private const string COMMAND_POSITION = "_pos";
    private const string COMMAND_ROTATION = "_rotate";
    private const string COMMAND_ACTIVE = "_active";
    private const string COMMAND_DELETE = "_delete";
    private const string COMMAND_ANIM = "_anim";
    private const string COMMAND_WRITE = "_write";
    private const string COMMAND_CALC = "_calc";
    
    #endregion

    #region PREFAB
    
    private const string CHARACTER_IMAGE_PREFAB = "CharacterImage";
    private const string SELECT_BUTTON_PREFAB = "SelectButton";

    #endregion

    #region SerializeField
    
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image foregroundImage;
    [SerializeField] private GameObject characterImages;
    [SerializeField] private GameObject selectButtons;
    [SerializeField] private Text mainText;
    [SerializeField] private Text nameText;
    [SerializeField] private ScrollRect backLog;
    [SerializeField] private GameObject nextPageIcon;
    [SerializeField] private string spritesDirectory = "Sprites/";
    [SerializeField] private string prefabsDirectory = "Prefabs/";
    [SerializeField] private string textFile = "Texts/Scenario";
    [SerializeField] private string animationsDirectory = "Animations/";
    [SerializeField] private string overrideAnimationClipName = "Clip";
    [SerializeField] private float captionSpeed = 0.2f;
    [SerializeField] private KeyCode skipKey = KeyCode.S;
    [SerializeField] private float skipSpeed = 0.2f;

    #endregion

    #region Other
    
    private float _waitTime = 0;
    private string _text = "";

    private bool isStop
    {
        get { return !mainText.transform.parent.gameObject.activeSelf || backLog.gameObject.activeSelf; }
    }

    private Dictionary<string, List<string>> _subScenes = new Dictionary<string, List<string>>();
    private Queue<string> _pageQueue;
    private Queue<char> _charQueue;
    private List<Image> _charaImageList = new List<Image>();
    private List<Button> _selectButtonList = new List<Button>();
    private List<AudioSource> _seList = new List<AudioSource>();
    private Dictionary<string, object> _params = new Dictionary<string, object>();
    private static Dictionary<string, object> _globalparams;
    private DataTable _dt = new DataTable();
    private bool _isSkip = false;
    
    #endregion

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        PushSkipButton();
        if (_isSkip) return;
        if (Input.GetMouseButtonDown(0)) OnClick();
        if (Input.GetMouseButtonDown(1)) OnClickRight();
        MouseScroll();
    }

    /**
    * 初期化する
    */
    private void Init()
    {
        if (_globalparams == null)
            _globalparams = new Dictionary<string, object>();
        _text = LoadTextFile(textFile);
        Queue<string> subScenes = SeparateString(_text, SEPARATE_SUBSCENE);
        foreach (string subScene in subScenes)
        {
            if (subScene.Equals("")) continue;
            Queue<string> pages = SeparateString(subScene, SEPARATE_PAGE);
            _subScenes[pages.Dequeue()] = pages.ToList<string>();
        }

        _pageQueue = ListToQueue(_subScenes.First().Value);
        ShowNextPage();
    }

    /**
    * 文字列のリストをキューに変更する
    */
    private Queue<string> ListToQueue(List<string> strs)
    {
        Queue<string> queue = new Queue<string>();
        foreach (string l in strs) queue.Enqueue(l);
        return queue;
    }

    /**
    * クリックしたときの処理
    */
    private void OnClick()
    {
        if (isStop) return;
        if (_charQueue.Count > 0)
            OutputAllChar();
        else
        {
            if (_selectButtonList.Count > 0)
                return;
            if (!ShowNextPage())
            {
                Exit();
            }
        }
    }

    /**
    * 右クリックした時の処理
    */
    private void OnClickRight()
    {
        GameObject mainWindow = mainText.transform.parent.gameObject;
        GameObject nameWindow = nameText.transform.parent.gameObject;
        mainWindow.SetActive(!mainWindow.activeSelf);
        if (nameText.text.Length > 0)
            nameWindow.SetActive(mainWindow.activeSelf);
        if (_charQueue.Count <= 0)
            nextPageIcon.SetActive(mainWindow.activeSelf);
    }

    /**
    * バックログの表示、非表示
    */
    private void MouseScroll()
    {
        if (backLog.gameObject.activeSelf && Input.GetKey(KeyCode.D) && backLog.verticalNormalizedPosition <= 0)
        {
            StopAllAnimation(false);
            backLog.gameObject.SetActive(false);
        }

        if (!backLog.gameObject.activeSelf && Input.GetKey(KeyCode.B))
        {
            StopAllAnimation(true);
            backLog.verticalNormalizedPosition = 0;
            backLog.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(backLog.verticalScrollbar.gameObject);
        }
    }

    /**
    * 文字送りするコルーチン
    */
    private IEnumerator ShowChars(float wait)
    {
        while (true)
        {
            if (!isStop)
            {
                if (!OutputChar()) break;
            }

            yield return new WaitForSeconds(wait);
        }

        yield break;
    }

    /**
    * 次の読み込みを待機するコルーチン
    */
    private IEnumerator WaitForCommand()
    {
        float time = 0;
        while (time < _waitTime)
        {
            if (!isStop) time += Time.deltaTime;
            yield return null;
        }

        _waitTime = 0;
        ShowNextPage();
        yield break;
    }

    /**
    * 1文字を出力する
    */
    private bool OutputChar()
    {
        if (_charQueue.Count <= 0)
        {
            nextPageIcon.SetActive(true);
            return false;
        }

        mainText.text += _charQueue.Dequeue();
        return true;
    }

    /**
    * 全文を表示する
    */
    private void OutputAllChar()
    {
        StopCoroutine(ShowChars(captionSpeed));
        while (OutputChar()) ;
        _waitTime = 0;
        nextPageIcon.SetActive(true);
    }

    /**
    * 次のページを表示する
    */
    private bool ShowNextPage()
    {
        if (_pageQueue.Count <= 0) return false;
        nextPageIcon.SetActive(false);
        ReadLine(_pageQueue.Dequeue());
        return true;
    }

    /**
    * 文字列を指定した区切り文字ごとに区切り、キューに格納したものを返す
    */
    private Queue<string> SeparateString(string str, char sep)
    {
        string[] strs = str.Split(sep);
        Queue<string> queue = new Queue<string>();
        foreach (string l in strs) queue.Enqueue(l);
        return queue;
    }

    /**
    * 文を1文字ごとに区切り、キューに格納したものを返す
    */
    private Queue<char> SeparateString(string str)
    {
        char[] chars = str.ToCharArray();
        Queue<char> charQueue = new Queue<char>();
        foreach (char c in chars) charQueue.Enqueue(c);
        return charQueue;
    }

    /**
    * 1行を読み出す
    */
    private void ReadLine(string text)
    {
        if (text[0].Equals(SEPARATE_COMMAND))
        {
            ReadCommand(text);
            if (_selectButtonList.Count > 0) return;
            if (_waitTime > 0)
            {
                StartCoroutine(WaitForCommand());
                return;
            }

            ShowNextPage();
            return;
        }

        text = ReplaceParameterForGame(text);
        string[] ts = text.Split(SEPARATE_MAIN_START);
        string name = ts[0];
        string main = ts[1].Remove(ts[1].LastIndexOf(SEPARATE_MAIN_END));

        nameText.text = name;
        if (name.Equals(""))
        {
            nameText.transform.parent.gameObject.SetActive(false);
            backLog.content.GetComponentInChildren<Text>().text += main;
        }
        else
        {
            nameText.transform.parent.gameObject.SetActive(true);
            backLog.content.GetComponentInChildren<Text>().text += text;
        }

        mainText.text = "";
        _charQueue = SeparateString(main);
        StartCoroutine(ShowChars(captionSpeed));
        backLog.content.GetComponentInChildren<Text>().text +=
            Environment.NewLine + Environment.NewLine;
    }

    /**
    * ゲーム中パラメーターの置き換え
    */
    private string ReplaceParameterForGame(string line)
    {
        string[] lines = line.Split(OUTPUT_PARAM);
        for (int i = 1; i < lines.Length; i += 2)
        {
            if (lines[i][0] == OUTPUT_GLOBAL_PARAM)
                lines[i] = _globalparams[lines[i].Remove(0, 1)].ToString();
            else
                lines[i] = _params[lines[i]].ToString();
        }

        return String.Join("", lines);
    }

    /**
    * コマンドの読み出し
    */
    private void ReadCommand(string cmdLine)
    {
        cmdLine = cmdLine.Remove(0, 1);
        Queue<string> cmdQueue = SeparateString(cmdLine, SEPARATE_COMMAND);
        foreach (string cmd in cmdQueue)
        {
            string[] cmds = cmd.Split((COMMAND_SEPARATE_PARAM + "").ToCharArray(), count: 3);
            if (cmds[0].Contains(COMMAND_BACKGROUND))
                SetBackgroundImage(cmds[0], cmds[1]);
            if (cmds[0].Contains(COMMAND_FOREGROUND))
                SetForegroundImage(cmds[0], cmds[1]);
            if (cmds[0].Contains(COMMAND_CHARACTER_IMAGE))
                SetCharacterImage(cmds[1], cmds[0], cmds[2]);
            if (cmds[0].Contains(COMMAND_JUMP))
                JumpTo(cmds[1]);
            if (cmds[0].Contains(COMMAND_SELECT))
                SetSelectButton(cmds[1], cmds[0], cmds[2]);
            if (cmds[0].Contains(COMMAND_WAIT_TIME))
                SetWaitTime(cmds[1]);
            if (cmds[0].Contains(COMMAND_CHANGE_SCENE))
                ChangeNextScene(cmds[1]);
            if (cmds[0].Contains(COMMAND_BACK_LOG))
                WriteBackLog(cmds[1]);
            if (cmds[0].Contains(COMMAND_PARAM))
                SetParameterForGame(cmds[1], cmds[0].Replace(COMMAND_PARAM, ""), cmds[2], _params);
            if (cmds[0].Contains(COMMAND_GLOBAL_PARAM))
                SetParameterForGame(cmds[1], cmds[0].Replace(COMMAND_GLOBAL_PARAM, ""), cmds[2], _globalparams);
            if (cmds[0].Contains(COMMAND_BRANCH))
                CompareJumpTo(cmds[1], cmds[2]);
        }
    }

    /**
    * 対応するシーンに切り替える
    */
    private void ChangeNextScene(string parameter)
    {
        parameter = GetParameterForCommand(parameter);
        SceneManager.LoadSceneAsync(parameter);
    }

    /**
    * 対応するラベルまでジャンプする
    */
    private void JumpTo(string parameter)
    {
        parameter = GetParameterForCommand(parameter);
        _pageQueue = ListToQueue(_subScenes[parameter]);
    }

    /**
    * 比較式がtrueだったら対応するラベルまでジャンプする
    */
    private void CompareJumpTo(string method, string parameter)
    {
        if ((bool)CalcParameterForGame(method)) JumpTo(parameter);
    }

    /**
    * 待機時間を設定する
    */
    private void SetWaitTime(string parameter)
    {
        parameter = GetParameterForCommand(parameter);
        _waitTime = float.Parse(parameter);
    }

    /**
    * バックログに記述する
    */
    private void WriteBackLog(string parameter)
    {
        parameter = GetParameterForCommand(parameter);
        backLog.content.GetComponentInChildren<Text>().text += parameter + Environment.NewLine + Environment.NewLine;
    }

    /**
    * 背景の設定
    */
    private void SetBackgroundImage(string cmd, string parameter)
    {
        cmd = cmd.Replace(COMMAND_BACKGROUND, "");
        SetImage(cmd, parameter, backgroundImage);
    }

    /**
    * 前景の設定
    */
    private void SetForegroundImage(string cmd, string parameter)
    {
        cmd = cmd.Replace(COMMAND_FOREGROUND, "");
        SetImage(cmd, parameter, foregroundImage);
    }

    /**
    * 立ち絵の設定
    */
    private void SetCharacterImage(string name, string cmd, string parameter)
    {
        cmd = cmd.Replace(COMMAND_CHARACTER_IMAGE, "");
        name = GetParameterForCommand(name);
        Image image = _charaImageList.Find(n => n.name == name);
        if (image == null)
        {
            image = Instantiate(Resources.Load<Image>(prefabsDirectory + CHARACTER_IMAGE_PREFAB),
                characterImages.transform);
            image.name = name;
            _charaImageList.Add(image);
        }

        SetImage(cmd, parameter, image);
    }

    /**
    * 選択肢の設定
    */
    private void SetSelectButton(string name, string cmd, string parameter)
    {
        cmd = cmd.Replace(COMMAND_SELECT, "");
        name = GetParameterForCommand(name);
        Button button = _selectButtonList.Find(n => n.name == name);
        if (button == null)
        {
            button = Instantiate(Resources.Load<Button>(prefabsDirectory + SELECT_BUTTON_PREFAB),
                selectButtons.transform);
            button.name = name;
            button.onClick.AddListener(() => SelectButtonOnClick(name));
            _selectButtonList.Add(button);
        }

        SetImage(cmd, parameter, button.image);
    }

    /**
    * 選択肢がクリックされた
    */
    private void SelectButtonOnClick(string label)
    {
        foreach (Button button in _selectButtonList) Destroy(button.gameObject);
        _selectButtonList.Clear();
        JumpTo('"' + label + '"');
        ShowNextPage();
    }

    /**
    * 画像の設定
    */
    private void SetImage(string cmd, string parameter, Image image)
    {
        cmd = cmd.Replace(" ", "");
        parameter = GetParameterForCommand(parameter);
        switch (cmd)
        {
            case COMMAND_TEXT:
                image.GetComponentInChildren<Text>().text = parameter;
                break;
            case COMMAND_SPRITE:
                image.sprite = LoadSprite(parameter);
                break;
            case COMMAND_COLOR:
                image.color = ParameterToColor(parameter);
                break;
            case COMMAND_SIZE:
                image.GetComponent<RectTransform>().sizeDelta = ParameterToVector3(parameter);
                break;
            case COMMAND_POSITION:
                image.GetComponent<RectTransform>().anchoredPosition = ParameterToVector3(parameter);
                break;
            case COMMAND_ROTATION:
                image.GetComponent<RectTransform>().eulerAngles = ParameterToVector3(parameter);
                break;
            case COMMAND_ACTIVE:
                image.gameObject.SetActive(ParameterToBool(parameter));
                break;
            case COMMAND_DELETE:
                _charaImageList.Remove(image);
                Destroy(image.gameObject);
                break;
            case COMMAND_ANIM:
                ImageSetAnimation(image, parameter);
                break;
        }
    }

    /**
    * スプライトをファイルから読み出し、インスタンス化する
    */
    private Sprite LoadSprite(string name)
    {
        return Instantiate(Resources.Load<Sprite>(spritesDirectory + name));
    }

    /**
    * パラメーターから色を作成する
    */
    private Color ParameterToColor(string parameter)
    {
        string[] ps = parameter.Replace(" ", "").Split(',');
        if (ps.Length > 3)
            return new Color32(byte.Parse(ps[0]), byte.Parse(ps[1]),
                byte.Parse(ps[2]), byte.Parse(ps[3]));
        else
            return new Color32(byte.Parse(ps[0]), byte.Parse(ps[1]),
                byte.Parse(ps[2]), 255);
    }

    /**
    * パラメーターからベクトルを取得する
    */
    private Vector3 ParameterToVector3(string parameter)
    {
        string[] ps = parameter.Replace(" ", "").Split(',');
        return new Vector3(float.Parse(ps[0]), float.Parse(ps[1]), float.Parse(ps[2]));
    }

    /**
    * パラメーターからboolを取得する
    */
    private bool ParameterToBool(string parameter)
    {
        string p = parameter.Replace(" ", "");
        return p.Equals("true") || p.Equals("TRUE");
    }

    /**
    * アニメーションを画像に設定する
    */
    private void ImageSetAnimation(Image image, string parameter)
    {
        Animator animator = image.GetComponent<Animator>();
        AnimationClip clip = ParameterToAnimationClip(image, parameter.Split(COMMAND_SEPARATE_ANIM));
        AnimatorOverrideController overrideController;
        if (animator.runtimeAnimatorController is AnimatorOverrideController)
            overrideController = (AnimatorOverrideController)animator.runtimeAnimatorController;
        else
        {
            overrideController = new AnimatorOverrideController();
            overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
            animator.runtimeAnimatorController = overrideController;
        }

        overrideController[overrideAnimationClipName] = clip;
        animator.Update(0.0f);
        animator.Play(overrideAnimationClipName, 0);
    }

    /**
    * パラメーターからアニメーションクリップを生成する
    */
    private AnimationClip ParameterToAnimationClip(Image image, string[] parameters)
    {
        string[] ps = parameters[0].Replace(" ", "").Split(',');
        string path = animationsDirectory + SceneManager.GetActiveScene().name + "/" + image.name;
        AnimationClip prevAnimation = Resources.Load<AnimationClip>(path + "/" + ps[0]);
        AnimationClip animation;
#if UNITY_EDITOR
        if (ps[3].Equals("Replay") && prevAnimation != null)
            return Instantiate(prevAnimation);
        animation = new AnimationClip();
        Color startcolor = image.color;
        Vector3[] start = new Vector3[3];
        start[0] = image.GetComponent<RectTransform>().sizeDelta;
        start[1] = image.GetComponent<RectTransform>().anchoredPosition;
        Color endcolor = startcolor;
        if (parameters[1] != "") endcolor = ParameterToColor(parameters[1]);
        Vector3[] end = new Vector3[3];
        for (int i = 0; i < 2; i++)
        {
            if (parameters[i + 2] != "")
                end[i] = ParameterToVector3(parameters[i + 2]);
            else end[i] = start[i];
        }

        AnimationCurve[,] curves = new AnimationCurve[4, 4];
        if (ps[3].Equals("EaseInOut"))
        {
            curves[0, 0] = AnimationCurve.EaseInOut(float.Parse(ps[1]), startcolor.r, float.Parse(ps[2]), endcolor.r);
            curves[0, 1] = AnimationCurve.EaseInOut(float.Parse(ps[1]), startcolor.g, float.Parse(ps[2]), endcolor.g);
            curves[0, 2] = AnimationCurve.EaseInOut(float.Parse(ps[1]), startcolor.b, float.Parse(ps[2]), endcolor.b);
            curves[0, 3] = AnimationCurve.EaseInOut(float.Parse(ps[1]), startcolor.a, float.Parse(ps[2]), endcolor.a);
            for (int i = 0; i < 2; i++)
            {
                curves[i + 1, 0] =
                    AnimationCurve.EaseInOut(float.Parse(ps[1]), start[i].x, float.Parse(ps[2]), end[i].x);
                curves[i + 1, 1] =
                    AnimationCurve.EaseInOut(float.Parse(ps[1]), start[i].y, float.Parse(ps[2]), end[i].y);
                curves[i + 1, 2] =
                    AnimationCurve.EaseInOut(float.Parse(ps[1]), start[i].z, float.Parse(ps[2]), end[i].z);
            }
        }
        else
        {
            curves[0, 0] = AnimationCurve.Linear(float.Parse(ps[1]), startcolor.r, float.Parse(ps[2]), endcolor.r);
            curves[0, 1] = AnimationCurve.Linear(float.Parse(ps[1]), startcolor.g, float.Parse(ps[2]), endcolor.g);
            curves[0, 2] = AnimationCurve.Linear(float.Parse(ps[1]), startcolor.b, float.Parse(ps[2]), endcolor.b);
            curves[0, 3] = AnimationCurve.Linear(float.Parse(ps[1]), startcolor.a, float.Parse(ps[2]), endcolor.a);
            for (int i = 0; i < 2; i++)
            {
                curves[i + 1, 0] = AnimationCurve.Linear(float.Parse(ps[1]), start[i].x, float.Parse(ps[2]), end[i].x);
                curves[i + 1, 1] = AnimationCurve.Linear(float.Parse(ps[1]), start[i].y, float.Parse(ps[2]), end[i].y);
                curves[i + 1, 2] = AnimationCurve.Linear(float.Parse(ps[1]), start[i].z, float.Parse(ps[2]), end[i].z);
            }
        }

        string[] b1 = { "r", "g", "b", "a" };
        for (int i = 0; i < 4; i++)
        {
            AnimationUtility.SetEditorCurve(
                animation,
                EditorCurveBinding.FloatCurve("", typeof(Image), "m_Color." + b1[i]),
                curves[0, i]
            );
        }

        string[] a = { "m_SizeDelta", "m_AnchoredPosition" };
        string[] b2 = { "x", "y", "z" };
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                AnimationUtility.SetEditorCurve(
                    animation,
                    EditorCurveBinding.FloatCurve("", typeof(RectTransform), a[i] + "." + b2[j]),
                    curves[i + 1, j]
                );
            }
        }

        if (!Directory.Exists("Assets/Resources/" + path))
            Directory.CreateDirectory("Assets/Resources/" + path);
        AssetDatabase.CreateAsset(animation, "Assets/Resources/" + path + "/" + ps[0] + ".anim");
        AssetDatabase.ImportAsset("Assets/Resources/" + path + "/" + ps[0] + ".anim");
#elif UNITY_STANDALONE
           animation = prevAnimation;
#endif
        return Instantiate(animation);
    }

    /**
    * 全てのアニメーションを一時停止・再開する
    */
    private void StopAllAnimation(bool isStop)
    {
        StopAnimation(isStop, foregroundImage);
        foreach (Image image in _charaImageList)
            StopAnimation(isStop, image);
        foreach (Button button in _selectButtonList)
            StopAnimation(isStop, button.image);
    }

    /**
    * アニメーションを一時停止・再開する
    */
    private void StopAnimation(bool isStop, Image image)
    {
        Animator animator = image.GetComponent<Animator>();
        if (isStop) animator.speed = 0;
        else animator.speed = 1;
    }

    /**
    * ゲーム中パラメーターの設定
    */
    private void SetParameterForGame(string name, string cmd, string parameter, Dictionary<string, object> _params)
    {
        cmd = cmd.Replace(" ", "");
        name = GetParameterForCommand(name);

        switch (cmd)
        {
            case COMMAND_WRITE:
                _params[name] = GetParameterForCommand(parameter);
                break;
            case COMMAND_CALC:
                _params[name] = CalcParameterForGame(parameter);
                break;
        }
    }

    /**
    * ゲーム中パラメーターの演算処理
    */
    private object CalcParameterForGame(string parameter)
    {
        parameter = GetParameterForCommand(parameter);
        object result = _dt.Compute(parameter, "");
        return result;
    }

    /**
    * コマンド中の「""」に挟まれた値を取り出す
    */
    private string GetParameterForCommand(string parameter)
    {
        parameter = parameter.Substring(parameter.IndexOf('"') + 1,
            parameter.LastIndexOf('"') - parameter.IndexOf('"') - 1);
        return ReplaceParameterForGame(parameter.Replace(" ", ""));
    }

    /**
    * テキストファイルを読み込む
    */
    private string LoadTextFile(string fname)
    {
        TextAsset textasset = Resources.Load<TextAsset>(fname);
        return textasset.text.Replace("\n", "").Replace("\r", "");
    }

    /**
    * 終了時の処理
    */
    private void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

    /**
    * スキップ用のキー(ボタン)を押した時の処理
    */
    private void PushSkipButton()
    {
        if (!_isSkip && Input.GetKey(skipKey))
        {
            _isSkip = true;
            StartCoroutine(Skip(skipSpeed));
        }

        if (Input.GetKeyUp(skipKey))
            _isSkip = false;
    }

    /**
    * スキップの処理
    */
    private IEnumerator Skip(float wait)
    {
        while (true)
        {
            if (isStop || !_isSkip || _waitTime > 0 || _selectButtonList.Count > 0)
                break;
            OutputAllChar();
            yield return new WaitForSeconds(wait);
            if (!ShowNextPage())
            {
                Exit();
            }
        }

        _isSkip = false;
        yield break;
    }
}