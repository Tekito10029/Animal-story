using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemInventory : MonoBehaviour
{
    public GameObject ItemSlot;
    public static ItemInventory instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }
}