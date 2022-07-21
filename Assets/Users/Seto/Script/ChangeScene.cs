using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            SceneManager.LoadScene("PrologueScene", LoadSceneMode.Single);
        }
    }
}
