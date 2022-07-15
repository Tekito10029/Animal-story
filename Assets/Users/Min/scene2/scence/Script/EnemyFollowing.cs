using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowing : MonoBehaviour
{
    Rigidbody2D rigid2D;
    [Header("Player")]
    [SerializeField]public GameObject player;

    [Header("Enemy")]
    [SerializeField]public GameObject enemy;

    [Header("Rock")]
    [SerializeField]public Transform stone1;
    [Header("Rock1")]
    [SerializeField]public Transform stone2;
    [Header("Rock2")]
    [SerializeField]public Transform stone3;
    [Header("Rock3")]
    [SerializeField]public Transform stone4;
    [Header("Rock4")]
    [SerializeField]public Transform stone5;

    [Header("Player Script")]
    public MoveTest mt;

    [Header("Enemy Following Speed")]
    public float speed = 3.0f;         

    [Header("Between Enemy and Rock Distance")]
    public float RockDistance;
    [Header("Between Player and Enemy Distance")]
    public float stopDistance;        
    [Header("Checker To Follow Player")]
    public bool isFollowing = false;   

    public bool isRock1 = false;
    public bool isRock2 = false;
    public bool isRock3 = false;
    public bool isRock4 = false;
    public bool isRock5 = false;
    
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        //stone1 = GameObject.Find("Stone1")
    }

   
    void Update()
    {
       
        Vector2 targetPos = player.transform.position;
        targetPos.y = transform.position.y;

        
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (isFollowing)
        {
            
            if (distance > stopDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                new Vector2(player.transform.position.x, enemy.transform.position.y),
                speed * Time.deltaTime);
            }
            
            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-2, 2, 2);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(2, 2, 2);
            }
        }

        
        //if(sotne1 != null)
       // {
             if(isRock1)
        {
                if(Vector2.Distance(transform.position,stone1.position) > RockDistance)
            {
                    transform.position = Vector2.MoveTowards(transform.position,stone1.position, speed * Time.deltaTime);  
            }  
        }
        //}
       
        if(isRock2)
        {
            
            if(Vector2.Distance(transform.position,stone2.position) > RockDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position,stone2.position, speed * Time.deltaTime);
            }   
        }
        if(isRock3)
        {
            
            if(Vector2.Distance(transform.position,stone3.position) > RockDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position,stone3.position, speed * Time.deltaTime);
            }   
        }
        if(isRock4)
        {
            
            if(Vector2.Distance(transform.position,stone4.position) > RockDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position,stone4.position, speed * Time.deltaTime);
            }   
        }
        if(isRock5)
        {
            
            if(Vector2.Distance(transform.position,stone5.position) > RockDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position,stone5.position, speed * Time.deltaTime);
            }   
        }
    } 

}