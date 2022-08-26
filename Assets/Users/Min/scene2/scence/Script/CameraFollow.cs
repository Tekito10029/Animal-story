using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
   public Transform Player;

   public Vector3 offset;
   
   [Range(1,10)]
   public float smoothing;
   
   private void FixedUpdate()
   {
    Follow();
   }
   void Follow()
   {
    Vector3 playerPosition = Player.position + offset;
    Vector3 smoothPositon = Vector3.Lerp(transform.position,playerPosition, smoothing * Time.fixedDeltaTime);
    transform.position = smoothPositon;
   }
    
}
