using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public GameObject player;

    public bool playerMove = false;
    
    Rigidbody2D rigid2D;
    public bool touchFlag = false;
   

    public EnemyFollowing EnemyCon;


    
    

    // Start is called before the first frame update
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
                this.transform.Translate(-0.1f, 0.0f, 0.0f);
                transform.localScale = new Vector3(-0.5f, 0.4710938f, 1);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(0.1f, 0.0f, 0.0f);
                transform.localScale = new Vector3(0.5f, 0.4710938f, 1);
            }
        }

        if(touchFlag == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                EnemyCon.isFollowing = true;
            }
            
        }

       
        
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HomeApp")
        {
            touchFlag = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HomeApp")
        {
            touchFlag = false;

        }
    }
}
