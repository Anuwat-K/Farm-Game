using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Farmmanage : MonoBehaviour
{
    public PlantObject selected_Plant;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void myplant(PlantObject plant)
    {
        selected_Plant = plant;
    }
}

