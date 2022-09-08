using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharactorController : MonoBehaviour
{
    private float speed = 10.0f;
    private Goal _goal;
    void Start()
    {
    }

    void Update()
    {
        Vector2 position = transform.position;

        if (Input.GetKey("left"))
        {
            position.x -= speed;
        }
        else if (Input.GetKey("right"))
        {
            position.x += speed;
        }

        transform.position = position;

    }
}
