using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coingscript : MonoBehaviour
{
    public bool applecount;
    [SerializeField]private GameObject Apllecounttext;

    private void Start()
    {
        applecount = false;
        Apllecounttext.SetActive(true);
    }

    private void Update()
    {
        if(applecount)
        {
            if(Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("Fire2"))
            {
                CounterScript.coinAmount += 1;
                Destroy(gameObject);
                Apllecounttext.SetActive(false);
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
