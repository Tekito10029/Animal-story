using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour
{   
  
    private bool enterAllowed;
    private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BlueDoor>())
        {
            sceneToLoad = "Map2";
            enterAllowed = true;
            Debug.Log("Touching");
        }
        else if (collision.GetComponent<BrownDoor>())
        {
            sceneToLoad = "Scene2";
            enterAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BlueDoor>() || collision.GetComponent<BrownDoor>())
        {
            enterAllowed = false;
        }
    }

    private void Update()
    {
        if (enterAllowed && Input.GetKey(KeyCode.K))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
