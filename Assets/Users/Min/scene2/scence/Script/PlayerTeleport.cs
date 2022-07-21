using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Portal1>().GetDestination1().position;
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            if(currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Protal2>().GetDestination2().position;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Teleporter"))
        {
            if(collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }

}
