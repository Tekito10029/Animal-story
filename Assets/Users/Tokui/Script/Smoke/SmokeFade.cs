using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmokeFade : MonoBehaviour
{
    GameObject me; // 自分のオブジェクト取得用変数
    public float fadeStart = 1f; // フェード開始時間
    public bool fadeIn = true; // trueの場合はフェードイン
    [SerializeField]
    public float fadeSpeed = 1f; // フェード速度指定


    // Start is called before the first frame update
    void Start()
    {
        me = this.gameObject; // 自分のオブジェクト取得
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeStart > 0f)
        {
            fadeStart -= Time.deltaTime;
        }
        else
        {
            if (fadeIn)
            {
                fadeInFunc();
            }
        }
    }

    void fadeInFunc()
    {
        if (me.GetComponent<Image>().color.a < 255)
        {
            UnityEngine.Color tmp = me.GetComponent<Image>().color;
            tmp.a = tmp.a + (Time.deltaTime * fadeSpeed);
            me.GetComponent<Image>().color = tmp;
        }
    }
}
