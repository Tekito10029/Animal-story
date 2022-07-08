using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RukaMove2 : MonoBehaviour
{
    Rigidbody2D rigid2D;
    private int Applecount = 0;
    private int GoldApplecount = 0;
    private int Inosisichck = 0;
    
    [Header("Ruka")]
    [SerializeField]private GameObject Ruka;
    
    [Header("Player Move Check")]
    public bool playerMove = false;
    
    [Header("Check to Inosisi")]
    public bool touchFlag = false;
    
    [Header("Rock")]
    public bool RockFlag = false;
    
    public bool Apple = false;
    public bool GoldApple = false;
    
    public bool Inosisi = false;

    public InosisiMove2 inosisiMove2;
    // Start is called before the first frame update
    void Start()
    {
        //Rigitbody取得
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //move();
        //inosisimv();
        //rockdest();
        //Efect();
        
        
        if (Inosisi)
        {
            Inosisichck++;
            Inosisi = false;
        }
        if (Apple)
        {
            Applecount++;
            Apple = false;
        }

        if (GoldApple)
        {
            GoldApplecount++;
            GoldApple = false;
        }
    }
    //プレイヤー移動
    public void move()
    {
        if (playerMove == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(-0.1f, 0.0f, 0.0f);
                transform.localScale = new Vector3(-0.1f, 0.1f, 1);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(0.1f, 0.0f, 0.0f);
                transform.localScale = new Vector3(0.1f, 0.1f, 1);
            }
        }
    }
    //イノシシをついてこさせる処理
    public void inosisimv()
    {
        if (touchFlag == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Applecount >= 1)
                {
                    inosisiMove2.isFollowing = true;
                    Applecount--;
                    Inosisi = true;
                }
            }
        }
    }
    
    //岩を壊す処理
    public void rockdest()
    {
        if (RockFlag == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (Applecount >= 1)
                {
                    if (Inosisichck <= 1)
                    {
                        inosisiMove2.isRock = true;
                        //EnemyCon.isFollowing = false;
                        //StartCoroutine(rockdestroy());
                        Destroy(inosisiMove2.Target.gameObject);
                        Applecount--;
                    }
                }
            }
        }
    }
    IEnumerator rockdestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(inosisiMove2.Target.gameObject);
    }

    //Colliderに入った時の判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Inosisi")
        {
            touchFlag = true;
        }
        if (collision.gameObject.tag == "rock")
        {
            RockFlag = true;
        }
    }
    //Colliderから出た時の判定
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Inosisi")
        {
            touchFlag = false;
        }
        if(collision.gameObject.tag == "rock")
        {
            RockFlag = false;
        }
    }
    //エフェクト
    /*private void Efect()
    {
        // 速度が0.1以上なら
        if(rigid2D.velocity.magnitude > 0.1f)
        {
            // 再生
            if (!kusa.isEmitting)
            {
                kusa.Play();
            }
        }
        else
        {
            // 停止
            if (kusa.isEmitting)
            {
                kusa.Stop();
            }
        }
    }*/
    
}
