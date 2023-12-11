using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSelected : MonoBehaviour
{
    // Start is called before the first frame update
    public PlantObject SE_plant;
    public Text Planttype;
    Farmmanage fm;
    void Start()
    {
        fm = FindObjectOfType<Farmmanage>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        Planttype.text = "Select : " + SE_plant.plantname;
        fm.selected_Plant = SE_plant;  // Define plant for plot 

    }
}


