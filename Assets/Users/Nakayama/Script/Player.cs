using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Animator animator = null;
    private Rigidbody2D rb = null;

    //private float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 position = transform.position;
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if (horizontalKey > 0)
        {
            //position.x -= speed;
            transform.localScale = new Vector3(1,1,1);
            animator.SetBool("walk", true);
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            //position.x += speed;
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("walk", true);
            xSpeed = -speed;
        }
        else
        {
            animator.SetBool("walk", false);
            xSpeed = 0.0f;
        }
        //transform.position = position;
        
    }
}
