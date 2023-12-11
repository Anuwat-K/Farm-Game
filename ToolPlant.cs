using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class base_tool : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeing = false;


    
        void OnTriggerStay2D(Collider2D collision) => Log(collision);
        void Log(Collider2D collision, [CallerMemberName] string message = null)
        {
            Debug.Log(collision.gameObject.name.ToString());
            collision.gameObject.GetComponent<PlotManager>().ChangeSprite();
        }



        // Update is called once per frame
        void Update()
    {
        if (isBeing == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            isBeing = true;
        }
    }
    private void OnMouseUp()
    {
        isBeing = false;
        this.gameObject.transform.localPosition = new Vector3(6, 5, 0);
        this.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }
}

