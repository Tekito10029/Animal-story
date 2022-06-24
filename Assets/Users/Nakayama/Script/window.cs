using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window : MonoBehaviour
{
    [SerializeField] GameObject text;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            text.SetActive(true);
        }
    }
}
