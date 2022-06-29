using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    Rigidbody2D rigid2D;
    
    [Header("Player")]
    [SerializeField]private GameObject player;
    [Header("EnemyFollowing Script")]
    [SerializeField]private EnemyFollowing EnemyCon;
    [Header("Hp Canvas")]
    [SerializeField]private GameObject HpCanvas;
    [Header("Check To Textbar")]
    [SerializeField]private GameObject CheckText;
    [Header("Check To Rock Text")]
    [SerializeField]private GameObject RockCheckText;
    
    
    [Header("Player Move Check")]
    public bool playerMove = false;
    [Header("Check to Enemy")]
    public bool touchFlag = false;
    [Header("Rock")]
    public bool RockFlag = false;
    
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        RockFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(-0.05f, 0.0f, 0.0f);
                transform.localScale = new Vector3(-1f, 1f, 1);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(0.05f, 0.0f, 0.0f);
                transform.localScale = new Vector3(1f, 1f, 1);
            }
        }

        if(touchFlag == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                EnemyCon.isFollowing = true; 
                CounterScript.coinAmount -= 1;
            } 
        }
        else 
        {
            HpCanvas.SetActive(false);
        }   
        if(CounterScript.coinAmount < 0)
        {
            EnemyCon.isFollowing = false;
        }
        if(RockFlag == true)
        {
            if(Input.GetKeyDown(KeyCode.Delete))
            {
                EnemyCon.isRock = true;
                EnemyCon.isFollowing = false;
                StartCoroutine(rockdestroy());
            }
        } 
        if(EnemyCon.isFollowing == false)
        {
            RockFlag = false;
        }
        if(EnemyCon.isFollowing)
        {
            CheckText.SetActive(false);
        }
        
    }
    IEnumerator rockdestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(EnemyCon.Rock.gameObject);
       // Destroy(EnemyCon.enemy.gameObject);
        EnemyCon.isRock = false;
        EnemyCon.isFollowing = true;

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HomeApp")
        {
            touchFlag = true;
           // HpCanvas.SetActive(true);
        } 
        if(collision.gameObject.tag == "textcheck")
        {
            HpCanvas.SetActive(true);
        }

        
    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HomeApp")
        {
            touchFlag = false;
        }
        /*if(collision.gameObject.tag == "textcheck")
        {
            CheckText.SetActive(false);
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "rock")
        {
            RockFlag = true;
            RockCheckText.SetActive(true);
        }
        else
        {
            RockFlag = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "rock")
        {
            RockCheckText.SetActive(false);
        }
    }
}
