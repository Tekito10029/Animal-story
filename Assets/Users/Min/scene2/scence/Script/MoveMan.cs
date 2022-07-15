using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMan : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX, moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }    
}
