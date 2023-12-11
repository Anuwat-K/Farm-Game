using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager current;
    private RectTransform rt;
    private RectTransform prt;
    private Boolean opened;
    private void Awake()
    {
        current = this;
        rt = GetComponent<RectTransform>();
        prt = transform.parent.GetComponent<RectTransform>();

    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShopButtom_Click()
    {
        float time = 0.2f;
        if (!opened)
        {
            LeanTween.moveX(prt, prt.anchoredPosition.x + rt.sizeDelta.x,time);
            opened = true;
            gameObject.SetActive(true);
        }
        else
        {
            LeanTween.moveX(prt, prt.anchoredPosition.x - rt.sizeDelta.x, time)
                .setOnComplete(delegate ()
                {
                    gameObject.SetActive(false);
                });
            opened = false;
        }
    }
}
