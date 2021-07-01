using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : Resource
{

    public Clothes() : base()
    {
        
    }

    public Clothes(int v) : base(v)
    {
        
    }


    public override float Wear(){
        value--;
        return 4f;
    }

    public override float UseTool(){
        value--;
        return 0.25f;
    }

    public override float Eat()
    {
        value--;
        return 0.5f;
    }
}
