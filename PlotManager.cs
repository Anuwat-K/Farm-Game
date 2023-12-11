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
        fm = FindAnyObjectByType<Farmmanage>();
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
        if (isPlanted && plantStage == selectedPlant.plantStages.Length-1)
        {
            Harvest();
        }
        else if (!isPlanted)
        {
            if (isPreplot == true)
            {
                Plant(fm.selected_Plant);
            }
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

    }

    public void Plant(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        isPlanted = true;
        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwStages;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
            plant.sprite = selectedPlant.plantStages[plantStage];
            //plantCollider.size = plant.sprite.bounds.size;
            //plantCollider.offset = new Vector2(0, plant.bounds.size.y / 2);
    }
}

