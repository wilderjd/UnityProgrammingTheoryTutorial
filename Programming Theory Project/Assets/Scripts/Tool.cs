using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
//this class uses inheritance
public class Tool : Resource
{
    public Tool() : base()
    {
        
    }


    // POLYMORPHISM
    //I override the default methods of the resouces
    //to show that tools are better at some things than others.
    //It's not good to eat a tool, but it is great being used as
    //a tool to harvest wood or cut fabric
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
