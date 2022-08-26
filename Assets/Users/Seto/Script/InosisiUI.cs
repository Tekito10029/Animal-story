using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InosisiUI : MonoBehaviour
{
    public GameObject nakama;

    public GameObject hanasu;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        nakama.SetActive(true);
        hanasu.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        nakama.SetActive(false);
        hanasu.SetActive(false);
    }
}
