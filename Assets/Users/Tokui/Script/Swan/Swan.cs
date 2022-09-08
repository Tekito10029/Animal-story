using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swan : MonoBehaviour
{
    [Header("Fogのイメージ")]
    [SerializeField] Image _fogimg; // 画像
    public bool Comb = false;
    public bool ItemUse = false;
    public bool MoveStop = false;
    public bool fadeNow = false;

    public GameObject target;
    [SerializeField] float speed = 5.0f;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("rukaHit");
            if (Comb == true)
            {
                MoveStop = true;
                if (Input.GetButton("Fire2"))
                {
                    ItemUse = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        MoveStop = false;
    }


    private void Update()
    {
        if (ItemUse == true)
        {
            if (MoveStop == false)
            {
                //自分の位置、ターゲット、速度
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
            }
            // 対象物へのベクトルを算出
            Vector3 toDirection = target.transform.position - transform.position;
            // 対象物へ回転する
            transform.rotation = Quaternion.FromToRotation(Vector3.left, toDirection);
        }

        if (Comb == true)
        {
            
            if (ItemUse == true)
            {
                if (Input.GetButton("Fire2"))
                {
                    if (fadeNow == false)
                    {
                        StartCoroutine("FadeIn"); // フェードインを開始
                        StartCoroutine("FadeOut");
                    }
                }

            }
        }
    }

    IEnumerator FadeIn()
    {
        fadeNow = true;
        _fogimg.gameObject.SetActive(true); // 画像をアクティブにする
 
        Color c = _fogimg.color;
        c.a = 1f; 
        _fogimg.color = c; // 画像の不透明度を1にする
 
        while (true)
        {
            yield return null; // 1フレーム待つ
            c.a -= 0.02f;
            _fogimg.color = c; // 画像の不透明度を下げる
 
            if (c.a <= 0f) // 不透明度が0以下のとき
            {
                c.a = 0f;
                _fogimg.color = c; // 不透明度を0
                
                break; // 繰り返し終了
            }
        }
    }

    IEnumerator FadeOut()
    {

        yield return new WaitForSeconds(6.0f);
        
        _fogimg.gameObject.SetActive(true); // 画像をアクティブにする
 
        Color c = _fogimg.color;
        c.a = 0f; 
        _fogimg.color = c; // 画像の不透明度を1にする
 
        while (true)
        {
            yield return null; // 1フレーム待つ
            c.a += 0.02f;
            _fogimg.color = c; // 画像の不透明度を下げる

            if (c.a >= 1f) // 不透明度が0以下のとき
            {
                c.a = 1f;
                _fogimg.color = c; // 不透明度を0
                break; // 繰り返し終了
            }
        }

        fadeNow = false;
    }
}
