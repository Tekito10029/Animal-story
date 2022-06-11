using UnityEngine;
using System.Collections;
using UnityEngine.UI;// UI機能を使用するために追記

public class Message : MonoBehaviour
{
    public bool isActive;// Canvasの表示非表示
    public GameObject canvas;// 使用するCanvas
    public Text messageText;// メッセージを表示する文字
    private string message;// 表示するメッセージ
    [SerializeField]
    private int maxTextLength = 90;// 1回のメッセージの最大文字数
    private int textLength = 0;// 1回のメッセージの現在の文字数
    [SerializeField]
    private int maxLine = 3;// メッセージの最大行数
    private int nowLine = 0;// 現在の行
    [SerializeField]
    private float textSpeed = 0.05f;// テキストスピード
    private float elapsedTime = 0f;// 経過時間
    private int nowTextNum = 0;// 今見ている文字番号
    private Image clickIcon;// マウスクリックを促すアイコン
    [SerializeField]
    private float clickFlashTime = 0.2f;// クリックアイコンの点滅秒数
    private bool isOneMessage = false;// 1回分のメッセージを表示したかどうか
    private bool isEndMessage = false;// メッセージをすべて表示したかどうか
    private string[] conversation;// 会話
    private int i = 0;// 文字列の列
    private int stringsCount = 0;// 文字列の総行数

    void Start()
    {
        gameObject.SetActive(true);// このオブジェクトを表示する
        clickIcon = canvas.transform.Find("Panel/Image").GetComponent<Image>();// clickIconをキャンバスの中のPanelの中のImageにする
        clickIcon.enabled = false;// clickIconのコンポーネントをオフにする
        messageText.text = "";// 文字を空白にする
    }

    void Update()
    {
        if (isEndMessage || message == null)// もし、メッセージが終わっていない、または設定されているなら
        {
            return;// 返す
        }

        if (!isOneMessage)// もし、1回に表示するメッセージを表示していなくて、
        {
            if (elapsedTime >= textSpeed)// テキスト表示時間が経過したら、
            {
                messageText.text += message[nowTextNum];// 次の文字番号にする

                if (message[nowTextNum] == '\n')// もし、改行文字だったら
                {
                    nowLine++;// 行数を足す
                }

                nowTextNum++;// 次の文字番号にする
                textLength++;// 次の文字数にする
                elapsedTime = 0f;// 経過時間を0にする

                if (nowTextNum >= message.Length || textLength >= maxTextLength || nowLine >= maxLine)// もし、メッセージを全部表示、または行数が最大数表示されたなら、
                {
                    isOneMessage = true;// isOneMessageをtrueにする
                }
            }

            elapsedTime += Time.deltaTime;// 経過時間に時間の経過分足す

            //ここから左クリックして一気に表示させる処理
            if (Input.GetMouseButtonDown(0))// もし、メッセージ表示中に左クリックされたら、
            {
                var allText = messageText.text;// allTextに、文字を入れる

                for (var i = nowTextNum; i < message.Length; i++)// 表示するメッセージ文繰り返す
                {
                    allText += message[i];//allTextに表示するi番目のメッセージを足す

                    if (message[i] == '\n')// もし、改行文字だったら、
                    {
                        nowLine++;// 今の行に一行足す
                    }

                    nowTextNum++;// 次の文字番号にする
                    textLength++;// 次の文字数にする

                    if (nowTextNum >= message.Length || textLength >= maxTextLength || nowLine >= maxLine)// もし、メッセージがすべて表示される、または１回表示限度を超えたなら、
                    {
                        messageText.text = allText;// messageTextをallTextにする
                        isOneMessage = true;// isOneMessageをtrueにする
                        break;// 処理を止める
                    }
                }
            }
        }

        else// クリックされていなければ、
        {
            elapsedTime += Time.deltaTime;// 経過時間に時間の経過分足す

            if (elapsedTime >= clickFlashTime)// クリックアイコンを点滅する時間を超えたなら、
            {
                clickIcon.enabled = !clickIcon.enabled;// クリックアイコンを点滅させる
                elapsedTime = 0f;// 経過時間を0にする
            }

            // クリックされたら次の文字を表示する処理
            if (Input.GetMouseButtonDown(0))// もし、クリックされたら、
            {
                messageText.text = "";// メッセージを空白にする
                nowLine = 0;// 今の行を0にする
                clickIcon.enabled = false;// クリックアイコンをオフにする
                elapsedTime = 0f;// 経過時間を0にする
                textLength = 0;// 文字数を0にする
                isOneMessage = false;// isOneMessageを0にする

                if (nowTextNum >= message.Length)// もし、メッセージが全部表示されていたら、
                {
                    nowTextNum = 0;// 現在の文字番号を0にする

                    if (i == stringsCount - 1)// もし、文字列の総行数に達したら、
                    {
                        isEndMessage = true;// isEndMessageをtrueにする
                        canvas.transform.GetChild(0).gameObject.SetActive(false);// キャンバスの子オブジェクトを非表示にする 
                    }

                    else// もし、文字列の総行数に達していなければ、
                    {
                        i++; //iを1増やす
                        SetMessage(conversation[i]);// SetMessageを実行する
                    }
                }
            }
        }
    }

    void SetMessage(string message)// SetMessage
    {
        this.message = message;// このオブジェクトのmessageをmessageにする
    }

    public void SetMessagePanel(string[] message)// SetMessagePanel
    {
        i = 0;// iを0にする
        stringsCount = message.Length;// 文字列の総行数をmessageの要素数にする
        conversation = message;// coversationをmessageにする
        canvas.SetActive(true);// キャンバスを表示する
        SetMessage(conversation[0]);// SetMessageを実行する
        canvas.transform.GetChild(1).gameObject.SetActive(true);// キャンバスの子オブジェクトを表示する
        isEndMessage = false;// isEndMessageをfalseにする
    }
}