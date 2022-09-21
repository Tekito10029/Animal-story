using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("x") || Input.GetButton("Fire2"))
        {
            SceneManager.LoadScene("PrologueScene", LoadSceneMode.Single);
        }
    }
}
