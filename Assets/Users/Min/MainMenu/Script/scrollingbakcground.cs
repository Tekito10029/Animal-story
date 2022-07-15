using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingbakcground : MonoBehaviour
{
   public BoxCollider2D collider;
   
   public Rigidbody2D rb;
   
   private float width;
   
   private float scrollingSpeed = -1f;
   
   void Start()
   {
       collider = GetComponent<BoxCollider2D>();
       rb = GetComponent<Rigidbody2D>();
       
       width = collider.size.x;
       collider.enabled = false;
       
       rb.velocity = new Vector2(scrollingSpeed, 0);
   }
   
   void Update() {
       {
           if(transform.position.x < -width)
           {
               Vector2 resetPositoin = new Vector2(width * 2f, 0);
               transform.position = (Vector2)transform.position + resetPositoin;
           }
       }
   }
}
