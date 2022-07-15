using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinAppleScript : MonoBehaviour
{
    public bool kinapplecount;
    [SerializeField]
    private GameObject ApplecountText;

    // Start is called before the first frame update
    void Start()
    {
        kinapplecount = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(kinapplecount)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                KinAppleCount.KinAppleAmount += 1;
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            kinapplecount = true;
            ApplecountText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            kinapplecount = false;
            ApplecountText.SetActive(false);
        }
    }
}
