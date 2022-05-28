using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
public class TextScript : MonoBehaviour
{
    public Text TextField;
    public TextAsset TextFile;
    private string TextData;
    private string[] TextSplitData;
    private int TextGroupNumber = 0;

    public GameObject CharaObject;
    private Image CharaImage;
    Sprite[] charasprites;
 
    void Start () {
        TextData = TextFile.text;
        TextSplitData = TextData.Split(char.Parse("\n"));
        TextField.text = TextSplitData[0];
        CharaImage = CharaObject.GetComponent<Image>();
        charasprites = Resources.LoadAll<Sprite>("CharaPack");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TextGroupNumber = (TextGroupNumber + 1) % TextSplitData.Length;
            switch (TextSplitData[TextGroupNumber].Replace("\r", "").Replace("\n", ""))
            {
                case "chara_set_a":
                    TextField.text = "";
                    CharaImage.sprite = charasprites[0];
                    TextGroupNumber++;
                    break;
                case "chara_set_b":
                    TextField.text = "";
                    CharaImage.sprite = charasprites[1];
                    TextGroupNumber++;
                    break;
                default:
                    break;
            }
            TextField.text = TextSplitData[TextGroupNumber];
        }
    }
}