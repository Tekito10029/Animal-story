using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Scene2",LoadSceneMode.Single);
    }
}
