using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvlchange : MonoBehaviour
{
    public KeyCode ChangeSceneKey1;
    
    public bool ChangeTrue;
    [SerializeField]
    private Transform _spawnPoint;
    [SerializeField]
    private Transform _spawnPoint1;
    
   
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        ChangeTrue = true;
       // SceneLoadText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ChangeTrue = false;
       // SceneLoadText.SetActive(false);
    }

    private void Start()
    {
       
    }

    // Update is called once per frame
    private void Update()
    {
        if(ChangeTrue && Input.GetKeyDown(ChangeSceneKey1))
        {   
            FindObjectOfType<MoveTest>().transform.position = _spawnPoint.position;
            FindObjectOfType<EnemyFollowing>().transform.position = _spawnPoint1.position;
        }
    }
}
