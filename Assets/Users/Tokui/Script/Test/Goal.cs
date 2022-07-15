using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private string NextScene = "";
    [SerializeField] private float FadeTime = 0.5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("判定");
            FadeManager.Instance.LoadScene(NextScene,FadeTime);
        }
    }
}
