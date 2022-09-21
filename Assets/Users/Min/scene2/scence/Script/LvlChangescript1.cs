using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlChangescript1 : MonoBehaviour
{
    public bool ChangeTrue;
    [SerializeField]
    private Transform _spawnPoint1;
    [SerializeField]
    private Transform _spawnPoint2;
    [SerializeField]
    private GameObject FadeingThing;
    [SerializeField]
    private GameObject MapUI4;
    [SerializeField]
    private GameObject MapUI5;
    
    






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
        if (ChangeTrue)
        {
            if (vertical < 0)
            {
                FadeingThing.SetActive(true);
                StartCoroutine(Change());
            }
            IEnumerator Change()
            {
                yield return new WaitForSeconds(1f);
                FindObjectOfType<MoveTest>().transform.position = _spawnPoint1.position;
                FindObjectOfType<EnemyFollowing>().transform.position = _spawnPoint2.position;
                MapUI4.SetActive(true);
                MapUI5.SetActive(false);
            }
           

        }


    }
}
