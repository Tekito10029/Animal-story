using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("すり抜けている");
    }
}
