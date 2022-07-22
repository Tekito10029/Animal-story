using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InosisiUI : MonoBehaviour
{
    public GameObject nakama;

    public GameObject hanasu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
