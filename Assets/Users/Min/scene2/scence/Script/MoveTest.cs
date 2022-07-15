using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    Rigidbody2D rigid2D;
    [SerializeField]private GameObject Ruka;
    [SerializeField]private EnemyFollowing EnemyCon;
    [SerializeField]private GameObject inosisitext;
    [SerializeField]private GameObject TalkUI;
    [SerializeField]private GameObject RockCheckText;
    [SerializeField]private GameObject RockUI;

    public bool playerMove = false;
    public bool touchFlag = false;
    public bool RockFlag1 = false;
    public bool RockFlag2 = false;
    public bool RockFlag3 = false;
    public bool RockFlag4 = false;
    public bool RockFlag5 = false;



    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        RockFlag1 = false;
        RockFlag2 = false;
        RockFlag3 = false;
        RockFlag4 = false;
        RockFlag5 = false;

    }

    void Update()
    {
        if (playerMove == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Translate(-0.1f, 0.0f, 0.0f);
                transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(0.1f, 0.0f, 0.0f);
                transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
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
        if(CounterScript.coinAmount < 1)
        {
            RockFlag1 = false;
            RockFlag2 = false;
            RockFlag3 = false;
            RockFlag4 = false;
            RockFlag5 = false;
        }
        if(EnemyCon.isFollowing == false)
        {
            RockFlag1 = false;
            RockFlag2 = false;
            RockFlag3 = false;
            RockFlag4 = false;
            RockFlag5 = false;
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

    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "inosisi")
            {
                touchFlag = true;
                inosisitext.SetActive(true);
                TalkUI.SetActive(true);
            } 
        }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "inosisi")
        {
            touchFlag = false;
            inosisitext.SetActive(false);
            TalkUI.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "stone1")
        {
            RockFlag1 = true;
            RockCheckText.SetActive(true);
            RockUI.SetActive(true);
        }
        if(collision.gameObject.tag == "stone2")
        {
            RockFlag2 = true;
            RockCheckText.SetActive(true);
            RockUI.SetActive(true);
        }
        if(collision.gameObject.tag == "stone3")
        {
            RockFlag3 = true;
            RockCheckText.SetActive(true);
            RockUI.SetActive(true);
        }
        if(collision.gameObject.tag == "stone4")
        {
            RockFlag4 = true;
            RockCheckText.SetActive(true);
            RockUI.SetActive(true);
        }
        if(collision.gameObject.tag == "stone5")
        {
            RockFlag5 = true;
            RockCheckText.SetActive(true);
            RockUI.SetActive(true);
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "stone1")
        {
            RockCheckText.SetActive(false);
            RockUI.SetActive(false);
            RockFlag1 = false;
        }
        if(collision.gameObject.tag == "stone2")
        {
            RockCheckText.SetActive(false);
            RockUI.SetActive(false);
            RockFlag2 = false;
        }
        if(collision.gameObject.tag == "stone3")
        {
            RockCheckText.SetActive(false);
            RockUI.SetActive(false);
            RockFlag3 = false;
        }
        if(collision.gameObject.tag == "stone4")
        {
            RockCheckText.SetActive(false);
            RockUI.SetActive(false);
            RockFlag4 = false;
        }
        if(collision.gameObject.tag == "stone5")
        {
            RockCheckText.SetActive(false);
            RockUI.SetActive(false);
            RockFlag5 = false;
        }
    }
}
