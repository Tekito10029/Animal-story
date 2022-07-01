using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private string NextScene = "";
    [SerializeField] private float FadeTime = 0.5f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ruka")
        {
            FadeManager.Instance.LoadScene(NextScene,FadeTime);
        }
    }
}
