using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITextandDestroy : MonoBehaviour
{
    [Header("UI Text")]
    public GameObject UiObject;
    private GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        UiObject.SetActive(false);
        Enemy = GameObject.FindWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D player)
    {
        if(player.gameObject.tag == "Player")
        {
            UiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
        
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(10);
        Destroy(UiObject);
    }
    void OnTriggerStay2D(Collider2D player) {
        if(player.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.Space))
            {
                Destroy(Enemy);
            }
        } 
    }
}
