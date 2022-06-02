using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RukaMove : MonoBehaviour
{
   Rigidbody2D rigid2D;
   private int Applecount = 0;
   private int Inosisichck = 0;
    
    [Header("Ruka")]
    [SerializeField]private GameObject Ruka;
    [Header("EnemyFollowing Script")]
    [SerializeField]private InosisiMove EnemyCon;


    [Header("Player Move Check")]
    public bool playerMove = false;
    [Header("Check to Inosisi")]
    public bool touchFlag = false;
    [Header("Rock")]
    public bool RockFlag = false;
    public bool Apple = false;
    public bool Inosisi = false;
    void Start()
    {
        //Rigitbody取得
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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

        if(touchFlag == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Applecount >= 1)
                {
                    EnemyCon.isFollowing = true;
                    Applecount--;
                    Inosisi = true;
                }
                
            }
        }
        /*else 
        {
            HpCanvas.SetActive(false);
        }*/   

        if(RockFlag == true)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                if (Applecount >= 1)
                {
                    if (Inosisichck == 1)
                    {
                        EnemyCon.isRock = true;
                        //EnemyCon.isFollowing = false;
                        //StartCoroutine(rockdestroy());
                        Destroy(EnemyCon.Target.gameObject);
                        Applecount--;
                    }
                }
            }
        } 
        if (Apple)
        {
            Applecount++;
            Apple = false;
        }

        if (Inosisi)
        {
            Inosisichck++;
            Inosisi = false;
        }
    }
    IEnumerator rockdestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(EnemyCon.Target.gameObject);
        //Destroy(EnemyCon.Inosisi.gameObject);
        //EnemyCon.isRock = false;
    }
    
    //private void OnCollisionEnter2D(Collision2D collision)
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

    //private void OnCollisionExit2D(Collision2D collision)
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

   
}
