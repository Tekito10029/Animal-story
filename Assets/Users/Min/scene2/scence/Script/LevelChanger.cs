using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField]
    private LevelConnection _connection;

    [SerializeField]
    private string _targetSceneName;
    
    [SerializeField]
    private Transform _spawnPoint;


    private void Start()
    {
        if(_connection == LevelConnection.ActiveConnection)
        {
            FindObjectOfType<MoveTest>().transform.position = _spawnPoint.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<MoveTest>();

        if(player != null)
        {
            LevelConnection.ActiveConnection = _connection;
            SceneManager.LoadScene(_targetSceneName);
        }
        
    }
}
