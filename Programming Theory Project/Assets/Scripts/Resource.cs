using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    protected int value;
    
    public Resource()
    {
        value = 4;
    }

    public Resource(int v)
    {
        value = v;
    }

    public virtual float Eat()
    {
        value--;
        return 1f;
    }

    public virtual float Burn()
    {
        value--;
        return 1f;
    }

    public virtual float UseTool()
    {
        value--;
        return 1f;
    }

    public virtual float Wear()
    {
        value--;
        return 1f;
    }

    public void Combine(Resource r){
        value = value + r.GetValue();
    }

    public int GetValue(){
        return value;
    }

    public void decreaseValue(int amount)
    {
        value -= amount;
    }

    public void decreaseValue()
    {
        value -= 1;
    }

}
