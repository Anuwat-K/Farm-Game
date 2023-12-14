using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Farmmanage : MonoBehaviour
{

    public int money = 100;
    public Text moneyTxt;
    public bool isPlanting = false;

    public PlantSelected selected_Plant;

    public Color buyColor = Color.green;
    public Color cancelColor = Color.red;


    // Start is called before the first frame update
    void Start()
    {
        moneyTxt.text = "$" + money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectPlant(PlantSelected newPlant)
    {
        if (selected_Plant == newPlant)
        {
            selected_Plant.btnImage.color = buyColor;
            selected_Plant.btnTxt.text = "Buy";
            selected_Plant = null;
            isPlanting = false;
        }
        else
        {
            selected_Plant = newPlant;
            selected_Plant.btnImage.color = cancelColor;
            selected_Plant.btnTxt.text = "Cancel";
            isPlanting = true;
        }
    }
    public void Transaction(int value)
    {
        money += value;
        moneyTxt.text = "$" + money;
    }

}

