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
    [SerializeField]public Transform stone1G;
    [SerializeField] public Transform bd1;
    [Header("Rock1")]
    [SerializeField]public Transform stone2;
    [SerializeField]public Transform stone2G;
    [SerializeField] public Transform bd2;
    [Header("Rock2")]
    [SerializeField]public Transform stone3;
    [SerializeField]public Transform stone3G;
    [SerializeField] public Transform bd3;
    [Header("Rock3")]
    [SerializeField]public Transform stone4;
    [SerializeField]public Transform stone4G;
    [SerializeField] public Transform bd4;
    [Header("Rock4")]
    [SerializeField]public Transform stone5;
    [SerializeField]public Transform stone5G;
    [SerializeField] public Transform bd5;
    [Header("BigRock")]
    [SerializeField]public Transform RockBig;
    [SerializeField]public Transform RockBigG;
    [SerializeField] public Transform bd6;

    [Header("Player Script")]
    public MoveTest mt;

    [Header("Enemy Following Speed")]
    public float speed = 1.0f;
    public float speed1 = 1.0f;
    public float speed2 = 1.0f;
    

    [Header("Between Enemy and Rock Distance")]
    public float RockDistance;
    [Header("Between Player and Enemy Distance")]
    public float stopDistance;        
    [Header("Checker To Follow Player")]
    public bool isFollowing = false; 
    public bool move1 = false;
    
      

    public bool isRock1 = false;
    public bool isRock2 = false;
    public bool isRock3 = false;
    public bool isRock4 = false;
    public bool isRock5 = false;
    public bool BigRock = false;
    
    private Animator animator = null;
    
    
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        
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
                animator.GetComponent<Animator>().enabled = true;
                animator.SetBool("walk", true);
            }
            else if(distance < stopDistance)
            {
                animator.GetComponent<Animator>().enabled = false;
            }

            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(2, 2, 1);
                animator.SetBool("walk", true);
            }   
            
            else if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-2, 2, 1);
                animator.SetBool("walk", true);
            }   
            
        }
        
       

        //Transform myTransform = this.transform;
        //if(sotne1 != null)
       // {
             if(isRock1)
        {
            if(Vector2.Distance(transform.position,bd1.position) > RockDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, bd1.position, speed1 * Time.deltaTime);
                animator.GetComponent<Animator>().enabled = true;
                StartCoroutine(backdistance1());
            }
            IEnumerator backdistance1()
            {
                yield return new WaitForSeconds(2);
                if(Vector2.Distance(transform.position,stone1G.position) > RockDistance)
                    {
                        transform.position = Vector2.MoveTowards(transform.position,stone1G.position, speed2 * Time.deltaTime);  
                        animator.GetComponent<Animator>().enabled = true;
                    }  
            }

        }
        //}
       
        if(isRock2)
        {
            
            if(Vector2.Distance(transform.position,bd2.position) > RockDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position,bd2.position, speed1 * Time.deltaTime);
                animator.GetComponent<Animator>().enabled = true;
                StartCoroutine(backdistance2());
            }  
            IEnumerator backdistance2()
            {
                yield return new WaitForSeconds(2);
                if(Vector2.Distance(transform.position,stone2G.position) > RockDistance)
                    {
                        transform.position = Vector2.MoveTowards(transform.position,stone2G.position, speed2 * Time.deltaTime);  
                        animator.GetComponent<Animator>().enabled = true;
                    }  
            } 
        }
        if(isRock3)
        {
            
            if(Vector2.Distance(transform.position,bd3.position) > RockDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position,bd3.position, speed1 * Time.deltaTime);
                animator.GetComponent<Animator>().enabled = true;
                StartCoroutine(backdistance3());
            }   
            IEnumerator backdistance3()
            {
                yield return new WaitForSeconds(2);
                if(Vector2.Distance(transform.position,stone3G.position) > RockDistance)
                    {
                        transform.position = Vector2.MoveTowards(transform.position,stone3G.position, speed2 * Time.deltaTime);  
                        animator.GetComponent<Animator>().enabled = true;
                    }  
            }
        }
        if(isRock4)
        {
            
            if(Vector2.Distance(transform.position,bd4.position) > RockDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position,bd4.position, speed1 * Time.deltaTime);
                animator.GetComponent<Animator>().enabled = true;
                StartCoroutine(backdistance4());
            } 
            IEnumerator backdistance4()
            {
                yield return new WaitForSeconds(2);
                if(Vector2.Distance(transform.position,stone4G.position) > RockDistance)
                    {
                        transform.position = Vector2.MoveTowards(transform.position,stone4G.position, speed2 * Time.deltaTime);  
                        animator.GetComponent<Animator>().enabled = true;
                    }  
            }  
        }
        if(isRock5)
        {
            
            if(Vector2.Distance(transform.position,bd5.position) > RockDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position,bd5.position, speed1 * Time.deltaTime);
                animator.GetComponent<Animator>().enabled = true;
                StartCoroutine(backdistance5());
            }  
            IEnumerator backdistance5()
            {
                yield return new WaitForSeconds(2);
                if(Vector2.Distance(transform.position,stone5G.position) > RockDistance)
                    {
                        transform.position = Vector2.MoveTowards(transform.position,stone5G.position, speed2 * Time.deltaTime);  
                        animator.GetComponent<Animator>().enabled = true;
                    }  
            } 
        }
        if(BigRock)
        {
            
            if(Vector2.Distance(transform.position,bd6.position) > RockDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position,bd6.position, speed1 * Time.deltaTime);
                animator.GetComponent<Animator>().enabled = true;
                StartCoroutine(backdistance6());
            }
               IEnumerator backdistance6()
            {
                yield return new WaitForSeconds(2);
                if(Vector2.Distance(transform.position,RockBigG.position) > RockDistance)
                    {
                        transform.position = Vector2.MoveTowards(transform.position,RockBigG.position, speed2 * Time.deltaTime);  
                        animator.GetComponent<Animator>().enabled = true;
                    }  
            } 
        }
    } 

}