using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvlchange : MonoBehaviour
{
    public KeyCode ChangeSceneKey1;
    public KeyCode ChangeSceneKey2;
    public bool ChangeTrue;
    [SerializeField]
    private string _targetSceneName;
    [SerializeField]
    private string _ChangeSceneName;
    [SerializeField]
    private Transform _spawnPoint;
    [SerializeField]
    private Transform _spawnPoint1;
    //[SerializeField]
    // private GameObject SceneLoadText;

    [SerializeField]
    private LevelConnection _connection;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ChangeTrue = true;
        //SceneLoadText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ChangeTrue = false;
        //SceneLoadText.SetActive(false);
    }

    private void Start()
    {
       if(_connection == LevelConnection.ActiveConnection)
        {
            FindObjectOfType<MoveTest>().transform.position = _spawnPoint.position;
            FindObjectOfType<EnemyFollowing>().transform.position = _spawnPoint1.position;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(ChangeTrue && Input.GetKeyDown(ChangeSceneKey1))
        {   
            LevelConnection.ActiveConnection = _connection;
            SceneManager.LoadScene(_targetSceneName);
        }

        if(ChangeTrue && Input.GetKeyDown(ChangeSceneKey2))
        {
            LevelConnection.ActiveConnection = _connection;
            SceneManager.LoadScene(_ChangeSceneName);
        }
    }
}
