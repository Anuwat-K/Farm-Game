using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour
{

    bool isPreplot = false;
    bool isPlanted  = false;
    public SpriteRenderer plant;

    BoxCollider2D plantCollider;

    int plantStage = 0;
    float timer;

    Farmmanage fm;
    PlantSell ps;
    public PlantObject selectedPlant;
    

    SpriteRenderer plot;
    public Sprite PrePlot;

    public void ChangeSprite()
       {
        if (!isPlanted)
        {
            plot.sprite = PrePlot;

            isPreplot = true;
        }
       }
    // Start is called before the first frame update
    void Start()
    {
        plot = GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        fm = transform.parent.GetComponent<Farmmanage>();
        ps = transform.parent.GetComponent<PlantSell>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantStage < selectedPlant.plantStages.Length-1)
            {
                timer = selectedPlant.timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("Click");
        if (isPlanted)
        {
            if (plantStage == selectedPlant.plantStages.Length - 1 && !fm.isPlanting)
            {
                Harvest();
            }
        }
        else if (fm.isPlanting && fm.selected_Plant.SE_plant.buyPrice <= fm.money)
        {
            Plant(fm.selected_Plant.SE_plant);
        }



    }

    private void OnMouseOver()
    {
        if (isPlanted)
        {
            plot.color = Color.red;
        }
        else
        {
            plot.color = Color.green;
        }
    }

    private void OnMouseExit()
    {
        plot.color= Color.white;
    }
    void Harvest()
    {
        
        isPlanted = false;
        plant.gameObject.SetActive(false);
        selectedPlant.count_item++;

    }

    public void Plant(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        isPlanted = true;
        plantStage = 0;
        fm.Transaction(-selectedPlant.buyPrice);
        UpdatePlant();
        timer = selectedPlant.timeBtwStages;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0, plant.bounds.size.y / 2);
    }
}

