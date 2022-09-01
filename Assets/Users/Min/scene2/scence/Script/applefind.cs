using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applefind : MonoBehaviour
{
    public bool applecount;
    

    private void Start()
    {
        applecount = false;
    }

    private void Update()
    {
        if(applecount)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                CounterScript.coinAmount += 1;
                Destroy(gameObject);
            }
           
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            applecount = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
                applecount = false;
               
        }
    }
}
