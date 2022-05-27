using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenceChange : MonoBehaviour
{
    public void btn_change_scence(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
