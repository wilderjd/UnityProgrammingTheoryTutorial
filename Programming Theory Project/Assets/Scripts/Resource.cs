using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    protected int value;
    
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

}
