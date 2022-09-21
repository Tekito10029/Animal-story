using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    Text coinText;
    public MoveTest MT;
    public static int coinAmount;
    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinAmount.ToString();
        if(coinAmount < 0)
        coinAmount = 0;

        if(coinAmount < 3)
        {
            MT.RockFlag3 = false;
        }
        if(coinAmount <= 1)
        {
            MT.touchFlag = false;
            MT.RockFlag4 = false;
        }

        if (coinAmount <= 0)
        {
            MT.RockFlag1 = false;
            MT.RockFlag2 = false;
        }
        if(coinAmount <= 2)
        {
            MT.RockFlag5 = false;
        }
    }
}
