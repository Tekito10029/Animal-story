using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    [Header("Player Speed")]
    public float Speed = 10.0f;

    [Header("Text true or false")]
    public bool touching = false;
    
    [Header("Text GameOject")]
    public GameObject Canvasbar;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Canvasbar.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

         if(touching)
        {
            Canvasbar.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Speed, vertical * Speed);   
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            touching = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            touching = false;
            Canvasbar.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.tag == "Enemy")
        {
            if(Input.GetKey(KeyCode.Space))
            {
                Destroy(GameObject.FindWithTag("Enemy"));
            }
        } 
    }
}
