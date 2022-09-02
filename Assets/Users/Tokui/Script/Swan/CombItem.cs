using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CombItem : MonoBehaviour
{
    [Header("櫛のイメージ")] 
    [SerializeField] private Image _combimg;

    public Swan _swan;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Destroy(gameObject);
                //_combimg.color = new Color32(0, 0, 0, 0);
                _swan.Comb = true;
            }
        }
    }
}
