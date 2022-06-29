using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
     private bool enterAllowed;
    private string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   private void Awake()
    {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    

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
