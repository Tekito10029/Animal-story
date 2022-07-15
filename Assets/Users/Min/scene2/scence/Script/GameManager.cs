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
}
