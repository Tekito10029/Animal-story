using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfollow : MonoBehaviour
{
    public float speed;
    public float StopDistance;
    private Transform target;

    void Start()
    {
       target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > StopDistance)
            {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
    }

    
    
}
