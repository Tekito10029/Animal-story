using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InosisiMove : MonoBehaviour
{
    Rigidbody2D rigid2D;
    [Header("Ruka")]
    [SerializeField]public GameObject Ruka;

    [Header("Inosisi")]
    [SerializeField]public GameObject Inosisi;

    [Header("Rock")]
    [SerializeField]public Transform Target;

    [Header("Player Script")]
    public RukaMove a;

    [Header("Enemy Following Speed")]
    public float speed = 3.0f;         

    [Header("Between Enemy and Rock Distance")]
    public float RockDistance;
    [Header("Between Player and Enemy Distance")]
    public float stopDistance;        
    [Header("Checker To Follow Player")]
    public bool isFollowing = false;   

    public bool isRock = false;
    
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
       
        Vector2 targetPos = Ruka.transform.position;
        targetPos.y = transform.position.y;

        
        float distance = Vector2.Distance(transform.position, Ruka.transform.position);

        if (isFollowing)
        {
            
            if (distance > stopDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    new Vector2(Ruka.transform.position.x, Inosisi.transform.position.y),
                    speed * Time.deltaTime);
            }
            
            if (Ruka.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(5, 5, 1);
            }
            else if (Ruka.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-5, 5, 1);
            }
        }

        if(isRock)
        {
            
            if(Vector2.Distance(transform.position,Target.position) > RockDistance)
            {
                transform.position = Vector2.MoveTowards
                    (transform.position,Target.position, speed * Time.deltaTime);
            }   
        }
    } 
}
