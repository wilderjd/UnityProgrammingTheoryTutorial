using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : Resource
{
    public Fuel() : base()
    {
        
    }

    public Fuel(int v) : base(v)
    {
        
    }

    public override float Eat()
    {
        value--;
        return 1f;
    }

    public override float Burn()
    {
        value--;
        return 3f;
    }

    public override float Wear(){
        value--;
        return 1f;
    }

}
