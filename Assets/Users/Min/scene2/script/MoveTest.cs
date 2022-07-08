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
    
    
    [Header("Player Move Check")]
    public bool playerMove = false;
    [Header("Check to Enemy")]
    public bool touchFlag = false;
    [Header("Rock")]
    public bool RockFlag = false;
    
    private string enemyTag = "Enemy";
    
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
        
        if (playerMove == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(-0.05f, 0.0f, 0.0f);
                transform.localScale = new Vector3(-1f, 1.0f, 1);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {

                this.transform.Translate(0.1f, 0.0f, 0.0f); 
                transform.localScale = new Vector3(0.5f, 0.4710938f, 1);

                this.transform.Translate(0.05f, 0.0f, 0.0f);
                transform.localScale = new Vector3(1f, 1.0f, 1);

            }
        }

        if(touchFlag == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EnemyCon.isFollowing = true;
            }
        }
        else 
        {
            HpCanvas.SetActive(false);
        }   

        if(RockFlag == true)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                EnemyCon.isRock = true;
                EnemyCon.isFollowing = false;
                StartCoroutine(rockdestroy());
            }
        } 
    }
    IEnumerator rockdestroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(EnemyCon.Target.gameObject);
        Destroy(EnemyCon.enemy.gameObject);
        EnemyCon.isRock = false;

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == enemyTag)
        {   
            Debug.Log("touch");
            touchFlag = true;
            HpCanvas.SetActive(true);
        } 
        
        if(collision.gameObject.tag == "rock")
        {
            RockFlag =  true;
        }
        
    }

    /*private void OnCollisionExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == enemyTag)
        {
            touchFlag = false;
            Debug.Log("touching");
        }
        if(collision.gameObject.tag == "rock")
        {
            RockFlag = false;
        }

    }*/
}
