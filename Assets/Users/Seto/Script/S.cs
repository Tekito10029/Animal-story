using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S : MonoBehaviour
{
    public GameObject _S;
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        _S.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _S.SetActive(false);
    }
}
