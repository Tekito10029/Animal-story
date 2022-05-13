using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkmove : MonoBehaviour
{
    public float speed = 0.1f;
    Rigidbody2D rb;
    public bool playerMove = false;
    public GameObject player;
   void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMove == false)
        {
            Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            transform.position = transform.position + horizontal * speed;
        }
        
        
    }
}
