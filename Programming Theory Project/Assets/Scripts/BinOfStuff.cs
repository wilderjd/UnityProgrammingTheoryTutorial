using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinOfStuff : MonoBehaviour
{
    public static BinOfStuff bin;

    // ENCAPSULATION
    //below are examples of encapsulation
    public float Warmth { get; private set;}
    public float Full { get; private set;}
    public float ClothStamina { get; private set;}

    Tool _tool = new Tool();
    public Tool tools 
    { 
        get => _tool; 
        set => _tool = value;
    }

    Fuel _fuel = new Fuel(0);
    public Fuel fuel 
    { 
        get => _fuel; 
        set => _fuel = value;
    }

    Food _food = new Food(0);
    public Food food 
    { 
        get => _food; 
        set => _food = value;
    }
    Clothes _clothes = new Clothes(0);
    public Clothes clothes 
    { 
        get => _clothes; 
        set => _clothes = value;
    }
    int resourceMode = 0;

    [SerializeField]
    Text message;

    [SerializeField]
    Text mode;

    [SerializeField]
    Button restart;
    public void Add(Resource r)
    {
        if (r is Tool){
            if (_tool==null)
            {
                _tool = (Tool)r;
            }else{
                _tool.Combine(r);
            }
        }
        if (r is Fuel)
        {
            if (_fuel==null)
            {
                _fuel = (Fuel)r;
            }else{
                _fuel.Combine(r);
            }
        }
        if (r is Food){
            if (_food==null)
            {
                _food = (Food)r;
            }else{
                _food.Combine(r);
            }
        }
        if (r is Clothes){
            if (_clothes==null)
            {
                _clothes = (Clothes)r;
            }else{
                _clothes.Combine(r);
            }
        }

    }

    void Awake()
    {
        if (bin==null){
            bin = this;
        }
        else if (bin != this)
        {
            Destroy(gameObject);
        }

        Full = 20;
        Warmth = 12;
        ClothStamina = 15;
        restart.gameObject.SetActive(false);

    }
    
    public static void Restart(){
        bin.Full = 20;
        bin.Warmth = 12;
        bin.ClothStamina = 15;
        bin._tool = new Tool();
        bin.message.text = "Game Reset";
        bin.restart.gameObject.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        bool tookAction = false;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool registeredHit = Physics.Raycast(ray,out hit);
            if (registeredHit)
            {
                if (hit.transform.name=="BinOfStuff")
                {
                    message.text = "In your bin you have" + _fuel.GetValue() + 
                    " wood, " + _food.GetValue() + " food, and " + _clothes.GetValue()+
                    " fabric.";
                }

                // ABSTRACTION
                //the following details are abstracted out
                //the details are in the specific methods
                if (hit.transform.name=="Picnic")
                {
                    havePicnic();
                }

                if (hit.transform.name=="FirePit")
                {
                    haveBonfire();

                }

                if (hit.transform.name=="Tree")
                {
                    chopWood();

                }

                if (hit.transform.name=="Dresser")
                {
                    getDressed();

                }

                if (hit.transform.name=="Refrigerator")
                {
                    message.text = "You get food";
                    Add(new Food());
                }

                if (hit.transform.name=="FabricRoll")
                {
                    cutFabric();

                }


                if (hit.transform.name=="ToolContainer")
                {
                    message.text = "You grab a new tool";
                    Add(new Tool());
                }
            }
            tookAction = true;
        }


        if (Input.GetMouseButtonDown(1))
        {
            resourceMode++;
            if (resourceMode>3)
            {
                resourceMode = 0;
            }

            if (resourceMode==0)
            {
                mode.text = "Mode: Using Tools";
            }
            else if (resourceMode==1)
            {
                mode.text = "Mode: Using Food";
            }
            else if (resourceMode==2)
            {
                mode.text = "Mode: Using Fuel";
            }
            else if (resourceMode==3)
            {
                mode.text = "Mode: Using Fabric";
            }
        }

        if (tookAction)
        {
            //when you do things, it makes you more hungery, wears out clothes, and burns the fire.
            Warmth--;
            ClothStamina--;
            Full--;
        }

        if (Warmth < 0)
        {
            message.text = "It is too cold. You die.";
            restart.gameObject.SetActive(true);

            
        }
        if (Full < 0)
        {
            message.text = "You starve to death.";
            restart.gameObject.SetActive(true);

            
        }
        if (ClothStamina < 0)
        {
            message.text = "Your clothes is too threadbare to protect\n you from the elements. You Die.";
            restart.gameObject.SetActive(true);

        }

    }


    private void cutFabric()
    {
                if (resourceMode==0)
                    {
                        if (_tool.GetValue()==0){
                            message.text = "No tools left";
                        }  else{ 
                        message.text = "You cut fabric with tools";
                        _clothes.Combine(new Clothes((int)_tool.UseTool()));
                        }
                    }
                    else if (resourceMode==1)
                    {     
                        if (_food.GetValue()==0){
                            message.text = "No Food left";
                        }  else{ 
                        message.text = "You try to cut fabric with food";
                        _clothes.Combine(new Clothes((int)_food.UseTool()));
                        }

                    }
                    else if (resourceMode==2)
                    {
                        if (_fuel.GetValue()==0){
                            message.text = "No wood left";
                        }  else{ 
                        message.text = "You cut fabric with wood";
                        _clothes.Combine(new Clothes((int)_fuel.UseTool()));
                        }
                    }
                    else if (resourceMode==3)
                    {
                        if (_clothes.GetValue()==0){
                            message.text = "No fabric left";
                        }  else{ 
                        message.text = "You cut fabric with fabric";
                        _clothes.Combine(new Clothes((int)_clothes.UseTool()));
                        }
                    }
    }

    private void getDressed()
    {
        if (resourceMode==0)
                    {
                        if (_tool.GetValue()==0){
                            message.text = "No tools left";
                        }  else{ 
                        message.text = "You try to wear a tool";
                        ClothStamina += _tool.Wear();
                        }
                    }
                    else if (resourceMode==1)
                    {     
                        if (_food.GetValue()==0){
                            message.text = "No Food left";
                        }  else{ 
                        message.text = "You try to wear food";
                        ClothStamina += _food.Wear();
                        }

                    }
                    else if (resourceMode==2)
                    {
                        if (_fuel.GetValue()==0){
                            message.text = "No wood left";
                        }  else{ 
                        message.text = "You wear leave off of your wood";
                        ClothStamina += _fuel.Wear();
                        }
                    }
                    else if (resourceMode==3)
                    {
                        if (_clothes.GetValue()==0){
                            message.text = "No fabric left";
                        }  else{ 
                        message.text = "You wear fabric as clothes";
                        ClothStamina += _clothes.Wear();
                        }
                    }
    }

    private void chopWood()
    {
                if (resourceMode==0)
                    {
                        if (_tool.GetValue()==0){
                            message.text = "No tools left";
                        }  else{ 
                        message.text = "You chop wood with tools";
                        _fuel.Combine(new Fuel((int)_tool.UseTool()));
                        }
                    }
                    else if (resourceMode==1)
                    {     
                        if (_food.GetValue()==0){
                            message.text = "No Food left";
                        }  else{ 
                        message.text = "You try to chop wood with food";
                        _fuel.Combine(new Fuel((int)_food.UseTool()));
                        }

                    }
                    else if (resourceMode==2)
                    {
                        if (_fuel.GetValue()==0){
                            message.text = "No wood left";
                        }  else{ 
                        message.text = "You chop wood with wood";
                        _fuel.Combine(new Fuel((int)_fuel.UseTool()));
                        }
                    }
                    else if (resourceMode==3)
                    {
                        if (_clothes.GetValue()==0){
                            message.text = "No fabric left";
                        }  else{ 
                        message.text = "You chop wood with fabric";
                        _fuel.Combine(new Fuel((int)_clothes.UseTool()));
                        }
                    }
    }

    private void haveBonfire()
    {
        if (resourceMode==0)
                    {
                        if (_tool.GetValue()==0){
                            message.text = "No tools left";
                        }  else{ 
                        message.text = "You throw a tool into the fire";
                        Warmth += _tool.Burn();
                        }
                    }
                    else if (resourceMode==1)
                    {     
                        if (_food.GetValue()==0){
                            message.text = "No Food left";
                        }  else{ 
                        message.text = "You throw Food into the fire";
                        Warmth += _food.Burn();
                        }

                    }
                    else if (resourceMode==2)
                    {
                        if (_fuel.GetValue()==0){
                            message.text = "No wood left";
                        }  else{ 
                        message.text = "You throw wood into the fire";
                        Warmth += _fuel.Burn();
                        }
                    }
                    else if (resourceMode==3)
                    {
                        if (_clothes.GetValue()==0){
                            message.text = "No fabric left";
                        }  else{ 
                        message.text = "You throw fabric into the fire";
                        Warmth += _clothes.Burn();
                        }
                    }
    }

    private void havePicnic(){
        
                    if (resourceMode==0)
                    {
                        message.text = "Use tools to get wood or food";
                    }
                    else if (resourceMode==1)
                    {  
                        if (_food.GetValue()==0){
                            message.text = "No Food left";
                        }  else{ 
                        message.text = "You Eat Food";
                        Full += _food.Eat();
                        }

                    }
                    else if (resourceMode==2)
                    {
                        if (_fuel.GetValue()==0){
                            message.text = "No wood left";
                        }  else{ 
                        message.text = "You eat leaves from  your wood";
                        Full += _fuel.Eat();
                        }
                    }
                    else if (resourceMode==3)
                    {
                        if (_food.GetValue()==0){
                            message.text = "No fabric left";
                        }  else{ 
                            message.text = "You eat fabric. Yuck.";
                            Full += _clothes.Eat();
                        }
                    }
    }

}
