using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSelected : MonoBehaviour
{
    // Start is called before the first frame update
    public PlantObject SE_plant;
    Farmmanage fm;
    public Text nameTxt;
    public Text priceTxt;
    public Image icon;

    public Image btnImage;
    public Text btnTxt;

    void Start()
    {
        fm = FindAnyObjectByType<Farmmanage>();
        InitializeUI();
    }

    // Update is called once per frame
    public void BuyPlant()
    {
        Debug.Log("Bought " + SE_plant.plantname);
        fm.SelectPlant(this);
    }
    void InitializeUI()
    {
        nameTxt.text = SE_plant.plantname;
        priceTxt.text = "$" + SE_plant.buyPrice;
        icon.sprite = SE_plant.icon;
    }
}



