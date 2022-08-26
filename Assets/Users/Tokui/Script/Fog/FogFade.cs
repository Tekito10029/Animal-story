using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogFade : MonoBehaviour
{
    [SerializeField] Image img; // 画像
    public bool haku = false;
    public bool itemuse = false;
    public bool fadeNow = false;
    
    private void Update()
    {
        if (haku == true)
        {
            if (Input.GetKey(KeyCode.X))
            {
                itemuse = true;
            }
        }

        if (itemuse == true)
        {
            fadeNow = true;
            StartCoroutine("FadeIn"); // フェードインを開始
            StartCoroutine("FadeOut");
            itemuse = false;
            fadeNow = false;
        }
    }

    private void ItemCount()
    {
        
    }
    
    IEnumerator FadeIn()
    {
        img.gameObject.SetActive(true); // 画像をアクティブにする
 
        Color c = img.color;
        c.a = 1f; 
        img.color = c; // 画像の不透明度を1にする
 
        while (true)
        {
            yield return null; // 1フレーム待つ
            c.a -= 0.02f;
            img.color = c; // 画像の不透明度を下げる
 
            if (c.a <= 0f) // 不透明度が0以下のとき
            {
                c.a = 0f;
                img.color = c; // 不透明度を0
                
                break; // 繰り返し終了
            }
        }
    }

    IEnumerator FadeOut()
    {

        yield return new WaitForSeconds(6.0f);
        
        img.gameObject.SetActive(true); // 画像をアクティブにする
 
        Color c = img.color;
        c.a = 0f; 
        img.color = c; // 画像の不透明度を1にする
 
        while (true)
        {
            yield return null; // 1フレーム待つ
            c.a += 0.02f;
            img.color = c; // 画像の不透明度を下げる

            if (c.a >= 1f) // 不透明度が0以下のとき
            {
                c.a = 1f;
                img.color = c; // 不透明度を0
                break; // 繰り返し終了
            }
        }
    }
}
