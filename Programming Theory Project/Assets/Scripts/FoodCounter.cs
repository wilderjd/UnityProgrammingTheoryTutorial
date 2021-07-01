using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodCounter : MonoBehaviour
{
    [SerializeField]
    Text foodText;

    // Update is called once per frame
    void Update()
    {

            foodText.text = "Full/Hunger: " + BinOfStuff.bin.Full;

    }
}
