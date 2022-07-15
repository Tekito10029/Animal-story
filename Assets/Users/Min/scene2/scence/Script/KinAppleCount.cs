using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KinAppleCount : MonoBehaviour
{
    Text KinAppleText;
    public static int KinAppleAmount;
    // Start is called before the first frame update
    void Start()
    {
        KinAppleText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        KinAppleText.text = KinAppleAmount.ToString();
        if (KinAppleAmount < 0)
            KinAppleAmount = 0;
    }
}
