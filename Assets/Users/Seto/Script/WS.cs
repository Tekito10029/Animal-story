using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WS : MonoBehaviour
{
    public GameObject _WS;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _WS.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _WS.SetActive(false);
    }
}
