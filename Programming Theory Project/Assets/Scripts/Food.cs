using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Resource
{
    public Food() : base()
    {
        
    }
    public Food(int v) : base(v)
    {
        
    }
    public override float Eat()
    {
        value--;
        return 3f;
    }

    public override float UseTool()
    {
        value--;
        return 0.25f;
    }

    public override float Wear()
    {
        value--;
        return 0.25f;
    }
    
}
