using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombItem : MonoBehaviour
{
    private FogFade _fogFade;

    public bool ItemGet = false;
    
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("rukaHit");
            if (Input.GetKeyDown(KeyCode.X))
            {
                ItemGet = true;
                this.gameObject.SetActive(false);
            }
        }
    }
}
