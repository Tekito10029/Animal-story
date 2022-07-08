using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D rigid2D;
    
    [Header("Player")]
    [SerializeField]private GameObject player;
    [Header("EnemyFollowing Script")]
    [SerializeField]private EnemyFollowing EnemyCon;
    [Header("Hp Canvas")]
    [SerializeField]private GameObject HpCanvas;
    
    
    [Header("Player Move Check")]
    public bool playerMove = false;
    [Header("Check to Enemy")]
    public bool touchFlag = false;
    [Header("Rock")]
    public bool RockFlag = false;
    private float speed = 0.05f;
    // Update is called once per frame
    void Update()
    {
      move();
    }

    private void move()
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
