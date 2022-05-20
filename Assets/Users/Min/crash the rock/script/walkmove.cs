using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class walkmove : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.1f;
    Rigidbody2D rb;
    public bool playerMove = false;
    [SerializeField]
    private LayerMask AnimalLayer;

    private bool AnimalFollowFlag = false;

    public GameObject Animal;
    
    [SerializeField]private bool touchFlag = false;
    [SerializeField]private bool AnimalTouchFlag = false;
    [SerializeField] private enemyfollow AnimalFollow;
    [SerializeField] private Image hp;
    public GameObject HpCanvas;


    
   void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(GetAnimalLayer())
        {
            if(AnimalFollow.ischarging)
            {
                AnimalTouchFlag = true;
            }
        }
        else
        {
            AnimalTouchFlag = false;
        }

        if(touchFlag || AnimalTouchFlag)
        {
            HpCanvas.SetActive(true);
            if(AnimalTouchFlag)
            {
                AnimalFollow.ischarging = true;
                AnimalFollow.following = true;
            }
        }
        if(playerMove == false)
        {
            Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            transform.position = transform.position + horizontal * speed;
        }
        
        
    */
    }
}
