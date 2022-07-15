using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1 : MonoBehaviour
{
    [SerializeField]
    private Transform destination1;

    public Transform GetDestination1()
    {
        return destination1;
    }
}
