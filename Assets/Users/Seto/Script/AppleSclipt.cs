using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AppleSclipt : MonoBehaviour
{
    [SerializeField]private RukaMove AppleCount;
    public int cou = 1;
    [Header("Ruka")] 
    public bool tuch = false;
    [Header("count")] 
    private RukaMove AppleCounter;
    private void Update()
    {
        if(tuch == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(gameObject);
                AppleCount.Apple = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tuch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tuch = false;
        }
    }
}
