using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolCounter : MonoBehaviour
{
    [SerializeField]
    Text toolText;


    // Update is called once per frame
    void Update()
    {
        if (BinOfStuff.bin.tools!=null)
        {
            toolText.text = "Tools: " + BinOfStuff.bin.tools.GetValue();
        }
        else
        {
            toolText.text = "Tools: 0";
        }
    }
}
