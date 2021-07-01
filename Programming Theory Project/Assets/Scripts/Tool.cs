using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : Resource
{
    public Tool() : base()
    {
        
    }
    public override float Eat()
    {
        return 0f;
    }

    public override float UseTool()
    {
        value--;
        return 4f;
    }

    public override string ToString()
    {
        return "Tool: " + this.GetValue();
    }


}
