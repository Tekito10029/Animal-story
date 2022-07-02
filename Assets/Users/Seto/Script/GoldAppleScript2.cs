using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldAppleScript2 : MonoBehaviour
{
    [SerializeField]private RukaMove2 GoldAppleCount;
    public int count = 1;
    [Header("Ruka")] 
    private bool tuch = false;
    void Update()
    {
        goldappledest();
    }
    //金リンゴを取ったら金リンゴを消す処理
    public void goldappledest()
    {
        //ルカと当たったら
        if (tuch == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(gameObject);
                GoldAppleCount.Apple = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tuch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tuch = false;
        }
    }
}
