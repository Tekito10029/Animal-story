using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InosisiMove2 : MonoBehaviour
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
    public bool isFollowing = false; 
    public bool isRock = false;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       //inosisifollow();
        //rockbr();
    }
    //プレイヤーについていく処理
    public void inosisifollow()
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
                transform.localScale = new Vector3(3, 3, 1);
            }
            else if (Ruka.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-3, 3, 1);
            }
        }
    }
    //岩を壊す処理
    public void rockbr()
    {
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
