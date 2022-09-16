using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCharactorController : MonoBehaviour
{
    private float speed = 10.0f;
    private Goal _goal;
    
    Vector2 move;
    void Start()
    {
    }

    void Update()
    {
        Vector2 position = transform.position;

        var _HorizontalInput = Input.GetAxisRaw("Horizontal");
        
        
        if (Input.GetKey("left") || _HorizontalInput <= 0.5)
        {
            position.x -= speed;
        }
        if (Input.GetKey("right")|| _HorizontalInput >= -0.5)
        {
            position.x += speed;
        }

        transform.position = position;
    }
}
