using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coingscript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CounterScript.coinAmount += 1;
            Destroy(gameObject);
        }
    }
}
