using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript2 : MonoBehaviour
{
    [SerializeField]private RukaMove2 AppleCount;
        public int cou = 1;
        [Header("Ruka")] 
        private bool tuch = false;
        [Header("count")] 
        public RukaMove2 AppleCounter;
         void Update()
        {
            appledest();
        }
        //リンゴを取ったらリンゴを消す処理
        public void appledest()
        {
            //ルカと当たったら
            if (tuch == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Destroy(gameObject);
                    AppleCount.Apple = true;
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
