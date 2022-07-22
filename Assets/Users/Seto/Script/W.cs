using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W : MonoBehaviour
{
    public GameObject _W;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _W.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _W.SetActive(false);
    }
}
