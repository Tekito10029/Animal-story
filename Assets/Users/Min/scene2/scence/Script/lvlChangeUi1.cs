using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlChangeUi1 : MonoBehaviour
{
    //public KeyCode ChangeSceneKey1;
    
    public bool ChangeTrue;
    [SerializeField]
    private Transform _spawnPoint1;
    [SerializeField]
    private Transform _spawnPoint2;
    [SerializeField]
    private Transform _spawnPoint3;
    [SerializeField]
    private Transform _spawnPoint4;
    [SerializeField]
    private GameObject FadeingThing;
    [SerializeField]
    private GameObject MapUI1;
    [SerializeField]
    private GameObject MapUI2;
    [SerializeField]
    private GameObject MapUI3;
    


    private void OnTriggerEnter2D(Collider2D other)
    {
        ChangeTrue = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ChangeTrue = false;  
    }

    private void Start()
    {
      
    }

    // Update is called once per frame
    private void Update()
    {
        
        float vertical = Input.GetAxisRaw("Vertical");
        if(ChangeTrue)
        {
            if(vertical > 0)
            {
                FadeingThing.SetActive(true);
                StartCoroutine(Change());
            }
            else if (vertical < 0)
            {
                FadeingThing.SetActive(true);
                StartCoroutine(Change1());
            }
            IEnumerator Change()
            {
                yield return new WaitForSeconds(1f);
                FindObjectOfType<MoveTest>().transform.position = _spawnPoint1.position;
                FindObjectOfType<EnemyFollowing>().transform.position = _spawnPoint2.position;
                MapUI1.SetActive(false);
                MapUI2.SetActive(true);
                
            }
            IEnumerator Change1()
            {
                yield return new WaitForSeconds(1f);
                FindObjectOfType<MoveTest>().transform.position = _spawnPoint3.position;
                FindObjectOfType<EnemyFollowing>().transform.position = _spawnPoint4.position;
                MapUI1.SetActive(false);
                MapUI3.SetActive(true);
            }

        }
    }
}
