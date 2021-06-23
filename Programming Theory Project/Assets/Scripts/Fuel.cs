using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : Resource
{
    public override float Eat()
    {
        value--;
        return 0.5f;
    }

    public override float Burn()
    {
        value--;
        return 2f;
    }

    public override float Wear(){
        value--;
        return 0.25f;
    }

}
