using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        //カメラとプレイヤーの位置を同じにする
        transform.position = new Vector3(playerPos.x, playerPos.y, -10);
    }
}
