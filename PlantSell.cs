using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSell : MonoBehaviour
{
    public PlantObject plantsell;
    Farmmanage fm;
    public Text nameTxt;
    public Text priceTxt;
    public Image icon;

    public Image btnImage;
    public Text btnTxt;
    public Text countItem;

    void Start()
    {
        plantsell.count_item = 0;
        fm = FindAnyObjectByType<Farmmanage>();
        InitializeUI();
    }
    private void Update()
    {
        InitializeUI();
    }

    // Update is called once per frame
    public void SellPlant()
    {
        if (plantsell.count_item > 0) {
            plantsell.count_item--;
            fm.Transaction(plantsell.sellPrice);
        }
    }
    void InitializeUI()
    {
        nameTxt.text = plantsell.plantname;
        priceTxt.text = "$" + plantsell.sellPrice;
        countItem.text = ">> "+plantsell.count_item;
        icon.sprite = plantsell.icon;
    }

}
