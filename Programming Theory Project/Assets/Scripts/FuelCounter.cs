using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelCounter : MonoBehaviour
{
    [SerializeField]
    Text fuelText;

    // Update is called once per frame
    void Update()
    {

            fuelText.text = "Warmth: " + BinOfStuff.bin.Warmth;

    }
}
