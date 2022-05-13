using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkmove : MonoBehaviour
{
    public float speed = 0.1f;
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * speed;
    }
}
