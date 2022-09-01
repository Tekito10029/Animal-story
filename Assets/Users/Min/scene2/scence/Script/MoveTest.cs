using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
   
    Rigidbody2D rigid2D;
    private Animator animator = null;
    [SerializeField]private GameObject Ruka;
    [SerializeField]private EnemyFollowing EnemyCon;
    [SerializeField]private GameObject inosisitext;
    [SerializeField]private GameObject TalkUI;
    [SerializeField]private GameObject RockCheckText;
    [SerializeField]private GameObject RockUI1;
    [SerializeField]private GameObject RockUI2;
    [SerializeField]private GameObject RockUI3;
    [SerializeField]private GameObject RockUI4;
    [SerializeField]private GameObject RockUI5;
    [SerializeField]private GameObject RockUI6;
    
    public bool playerMove = false;
    public bool playerMove1 = false;
    public bool touchFlag = false;
    public bool RockFlag1 = false;
    public bool RockFlag2 = false;
    public bool RockFlag3 = false;
    public bool RockFlag4 = false;
    public bool RockFlag5 = false;
    public bool RockFlag6 = false;



    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        RockFlag1 = false;
        RockFlag2 = false;
        RockFlag3 = false;
        RockFlag4 = false;
        RockFlag5 = false;
        RockFlag6 = false;
    }

    void Update()
    {
        if (playerMove == false)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    this.transform.Translate(-0.03f, 0.0f, 0.0f);
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                    animator.SetBool("walk", true);
                }
                else
                {
                    animator.SetBool("walk", false);
                }
            }
            if(playerMove1 == false)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    this.transform.Translate(0.03f, 0.0f, 0.0f);
                    transform.localScale = new Vector3(1f, 1f, 1f);
                    animator.SetBool("walk", true);
                }
            }
            if(touchFlag == true)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                EnemyCon.isFollowing = true; 
                CounterScript.coinAmount -= 1;
            } 
        }
        if(EnemyCon.isFollowing == true)
        {
            inosisitext.SetActive(false);
            TalkUI.SetActive(false);
        }
        if(CounterScript.coinAmount < 0)
        {
            EnemyCon.isFollowing = false;
        }
        if(KinAppleCount.KinAppleAmount < 0)
        {
            EnemyCon.isFollowing = false;
        }
        if(CounterScript.coinAmount < 1)
        {
            RockFlag1 = false;
            RockFlag2 = false;
            RockFlag3 = false;
            RockFlag4 = false;
            RockFlag5 = false;
        }
        if(KinAppleCount.KinAppleAmount < 1)
        {
            RockFlag6 = false;
        }
        if(EnemyCon.isFollowing == false)
        {
            RockFlag1 = false;
            RockFlag2 = false;
            RockFlag3 = false;
            RockFlag4 = false;
            RockFlag5 = false;
            RockFlag6 = false;
        }
        
        if(RockFlag1 == true)
        {
            if(Input.GetKey(KeyCode.X))
            {
                EnemyCon.isRock1 = true;
                EnemyCon.isFollowing = false;
                CounterScript.coinAmount -= 1;
                StartCoroutine(rockdestroy1());
            }
        }
        
        if(RockFlag2 == true)
        {
            if(Input.GetKey(KeyCode.X))
            {
                EnemyCon.isRock2 = true;
                EnemyCon.isFollowing = false;
                CounterScript.coinAmount -= 1;
                StartCoroutine(rockdestroy2());
            }
        }
        if(RockFlag3 == true)
        {
            if(Input.GetKey(KeyCode.X))
            {
                EnemyCon.isRock3 = true;
                EnemyCon.isFollowing = false;
                CounterScript.coinAmount -= 1;
                StartCoroutine(rockdestroy3());
            }
        }
        if(RockFlag4 == true)
        {
            if(Input.GetKey(KeyCode.X))
            {
                EnemyCon.isRock4 = true;
                EnemyCon.isFollowing = false;
                CounterScript.coinAmount -= 1;
                StartCoroutine(rockdestroy4());
            }
        }
        if(RockFlag5 == true)
        {
            if(Input.GetKey(KeyCode.X))
            {
                EnemyCon.isRock5 = true;
                EnemyCon.isFollowing = false;
                CounterScript.coinAmount -= 1;
                StartCoroutine(rockdestroy5());
            }
        }
        if(RockFlag6 == true)
        {
            if(Input.GetKey(KeyCode.X))
            {
                EnemyCon.BigRock = true;
                EnemyCon.isFollowing = false;
                KinAppleCount.KinAppleAmount -= 1;
                StartCoroutine(rockdestroy6());
            }
        }
        IEnumerator rockdestroy1()
        {
            yield return new WaitForSeconds(2);
            if(EnemyCon.stone1 != null)
            {
                 Destroy(EnemyCon.stone1.gameObject);
            }
            EnemyCon.isRock1 = false;
            EnemyCon.isFollowing = true;
        }
        IEnumerator rockdestroy2()
        {
            yield return new WaitForSeconds(2);
            if(EnemyCon.stone2 != null)
            {
                Destroy(EnemyCon.stone2.gameObject);
            }
            EnemyCon.isRock2 = false;
            EnemyCon.isFollowing = true;
        }
        IEnumerator rockdestroy3()
        {
            yield return new WaitForSeconds(2);
            if(EnemyCon.stone3 !=null)
            {
                Destroy(EnemyCon.stone3.gameObject);
            }
            EnemyCon.isRock3 = false;
            EnemyCon.isFollowing = true;
        }
        IEnumerator rockdestroy4()
        {
            yield return new WaitForSeconds(2);
            if(EnemyCon.stone4 != null)
            {
                Destroy(EnemyCon.stone4.gameObject);
            }
            EnemyCon.isRock4 = false;
            EnemyCon.isFollowing = true;
        }
        IEnumerator rockdestroy5()
        {
            yield return new WaitForSeconds(2);
            if(EnemyCon.stone5 != null)
            {
                Destroy(EnemyCon.stone5.gameObject);
            }
            EnemyCon.isRock5 = false;
            EnemyCon.isFollowing = true;
        }
        IEnumerator rockdestroy6()
        {
            yield return new WaitForSeconds(2);
            if(EnemyCon.RockBig != null)
            {
                Destroy(EnemyCon.RockBig.gameObject);
            }
            EnemyCon.BigRock = false;
            EnemyCon.isFollowing = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "inosisi")
            {
                touchFlag = true; 
            } 
            if(collision.gameObject.tag == "textcheck")
            {
                inosisitext.SetActive(true);
                TalkUI.SetActive(true);
            }
        }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "inosisi")
        {
            touchFlag = false;
        }
        if(collision.gameObject.tag == "textcheck")
        {
            inosisitext.SetActive(false);
            TalkUI.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "stone1")
        {
            playerMove1 = true;
            RockFlag1 = true;
            RockCheckText.SetActive(true);
            RockUI1.SetActive(true);
        }
        if(collision.gameObject.tag == "stone2")
        {
            playerMove1 = true;
            RockFlag2 = true;
            //RockCheckText.SetActive(true);
            RockUI2.SetActive(true);
        }
        if(collision.gameObject.tag == "stone3")
        {
            playerMove1 = true;
            RockFlag3 = true;
            //RockCheckText.SetActive(true);
            RockUI3.SetActive(true);
        }
        if(collision.gameObject.tag == "stone4")
        {
            playerMove1 = true;
            RockFlag4 = true;
            //RockCheckText.SetActive(true);
            RockUI4.SetActive(true);
        }
        if(collision.gameObject.tag == "stone5")
        {
            playerMove1 = true;
            RockFlag5 = true;
            //RockCheckText.SetActive(true);
            RockUI5.SetActive(true);
        }
        if(collision.gameObject.tag == "RockBig")
        {
            playerMove1 = true;
            RockFlag6 = true;
            //RockCheckText.SetActive(true);
            RockUI6.SetActive(true);
        }
        if(collision.gameObject.tag == "wall1")
        {
            playerMove = true;
            animator.SetBool("walk", false);
        }
        if(collision.gameObject.tag == "wall2")
        {
            playerMove1 = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "stone1")
        {
            playerMove1 = false;
            RockCheckText.SetActive(false);
            RockUI1.SetActive(false);
            RockFlag1 = false;
        }
        if(collision.gameObject.tag == "stone2")
        {
            playerMove1 = false;
            //RockCheckText.SetActive(false);
            RockUI2.SetActive(false);
            RockFlag2 = false;
        }
        if(collision.gameObject.tag == "stone3")
        {
            playerMove1 = false;
           // RockCheckText.SetActive(false);
            RockUI3.SetActive(false);
            RockFlag3 = false;
        }
        if(collision.gameObject.tag == "stone4")
        {
            playerMove1 = false;
           // RockCheckText.SetActive(false);
            RockUI4.SetActive(false);
            RockFlag4 = false;
        }
        if(collision.gameObject.tag == "stone5")
        {
            playerMove1 = false;
            //RockCheckText.SetActive(false);
            RockUI5.SetActive(false);
            RockFlag5 = false;
        }
        if(collision.gameObject.tag == "RockBig")
        {
            playerMove1 = false;
            //RockCheckText.SetActive(false);
            RockUI6.SetActive(false);
            RockFlag6 = false;
        }
        if(collision.gameObject.tag == "wall1")
        {
            playerMove = false;
        }
        if(collision.gameObject.tag == "wall2")
        {
            playerMove1 = false;
        }
    }
}
