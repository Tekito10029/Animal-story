using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfollow : MonoBehaviour
{
   /* public float speed;
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
    }*/

    public GameObject player;
    public GameObject enemy;

    public float speed = 0.1f;
    public float StopDistance;

    public walkmove mk;

    private bool following = false;
    private bool follow = false;
    public bool enemyMove = true;

    Rigidbody2D rb;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 targetPos = player.transform.position;
        targetPos.y = transform.position.y;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(following)
        {
            if(distance > StopDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                new Vector2(player.transform.position.x, enemy.transform.position.y),
                speed + Time.deltaTime);
            }
            if(player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if(player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

        }
        if(enemyMove == false);
        {
            Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            transform.position = transform.position + horizontal * speed;
        }
        
       
        if(Input.GetKeyDown(KeyCode.Space) && follow == false)
        {
            mk.playerMove = !mk.playerMove;
            Following();
            enemyMove = !enemyMove;
            follow = !follow;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && follow == true)
        {
            following = false;
            enemyMove = true;
            mk.playerMove = false;
            PlayerChange();
        }

        if(follow == true && Input.GetKeyDown("e"))
        {
            following = true;
            follow = !follow;
        }
    }
    public void Following()
    {
        following = !following;
    }

    public void PlayerChange()
    {
        mk.playerMove = !mk.playerMove;

        Following();
        enemyMove = !enemyMove;
    }
    
    
}
