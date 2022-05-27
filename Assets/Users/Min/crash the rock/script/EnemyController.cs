using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  /*  public GameObject Player;
    public GameObject enemy;
    public float stopDistance;
    public PlayerController mt;
    public bool isCharging = true;

    public bool isFollowing = true;
    public bool enemyMove = true;
    Rigidbody2D rb2d;
    public float inputSpeed;


    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Vector2 targetPos = Player.transform.position;
        //targetPos.y = transform.position.y;

       // float distance = Vector2.Distance(transform.position, Player.transform.position);
        
    }*/

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
