using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolContainer : MonoBehaviour
{

    [SerializeField]
    Text message;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool registeredHit = Physics.Raycast(ray,out hit);
            if (registeredHit)
            {
                if (hit.transform.name=="ToolContainer")
                {
                    message.text = "You add a tool to your bin";
                    BinOfStuff.bin.Add(new Tool());
                }
            }
        }
    }
}
