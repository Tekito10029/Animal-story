using UnityEngine;
using System.Collections;

public class MessageScript : MonoBehaviour
{
    public Message messageScript;// Messageスクリプトを読み込む
    public string[] message;// 表示させるメッセージ

    void Start()
    {
        StartCoroutine("Message");// Messageコルーチンを実行する
    }

    IEnumerator Message()// Messageコルーチン 
    {
        yield return new WaitForSeconds(0.01f);// 0.01秒待つ
        messageScript.SetMessagePanel(message);// messageScriptのSetMessagePanelを実行する
    }
}