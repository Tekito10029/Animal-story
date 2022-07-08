using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(-0.05f, 0.0f, 0.0f);
                transform.localScale = new Vector3(-1f, 1.0f, 1);
            }

        if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(0.05f, 0.0f, 0.0f);
                transform.localScale = new Vector3(1f, 1.0f, 1);
            }
        if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate(-0.00f, 0.05f, 0.0f);
                transform.localScale = new Vector3(-1f, 1.0f, 1);
            }

        if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.Translate(0.00f, 0.05f, 0.0f);
                transform.localScale = new Vector3(1f, 1.0f, 1);
            }
            
    }
}
