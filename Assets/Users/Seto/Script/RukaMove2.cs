using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RukaMove2 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-0.1f, 0.0f, 0.0f);
            transform.localScale = new Vector3(-1f, 1f, 1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(0.1f, 0.0f, 0.0f);
            transform.localScale = new Vector3(1f, 1f, 1);
        }
    }
}
