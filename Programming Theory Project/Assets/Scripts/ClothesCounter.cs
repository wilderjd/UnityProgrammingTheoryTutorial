using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesCounter : MonoBehaviour
{
    [SerializeField]
    Text clothesText;
    
    // Update is called once per frame
    void Update()
    {

            clothesText.text = "Clothing Stamina: " + BinOfStuff.bin.ClothStamina;

    }
}
