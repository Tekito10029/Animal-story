using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject teleport;
    private GameObject player;
    private GameObject inosisi;

    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private Transform spawnPoint1;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inosisi = GameObject.FindWithTag("inosisi");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {   
            
                player.transform.position = spawnPoint.position;//new Vector2(teleport.transform.position.x, teleport.transform.position.y);
            
            
        }
        if(collision.tag == "inosisi")
        {
            inosisi.transform.position = spawnPoint1.position;//new Vector2(teleport.transform.position.x, teleport.transform.position.y);
        }
    }
}
