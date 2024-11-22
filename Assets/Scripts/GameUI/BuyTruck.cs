using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyTruck : MonoBehaviour
{
    public TruckImageManager TruckImageManager;
    public TMP_Text ButtonText;
    public int TruckCost = 5;
    //Gundo edit
    private void Start()
    {
        ButtonText.text = "Buy Truck: \n" + TruckCost;
    }
    public void BuyNewTruck()
    {
        SRC.instance.ButtonPress();
        if(TruckImageManager.TrucksAvailable < 5)
        {
            if(GameManager.instance.coins >= TruckCost)
            {
                Spawner.instance.spawnCell(Selecting.Instance.placeholder);
                //Station.instance.SendOut(Selecting.Instance.placeholder);
                GameManager.instance.UseCoins(TruckCost);
                GameManager.instance.TruckCount++;
                TruckImageManager.TrucksAvailable++;
                TruckImageManager.TrucksInside++;
                TruckCost += 10;
                ButtonText.text = "Buy Truck: \n" + TruckCost;
                TruckImageManager.ChangeImage();
            }
        }
    }
}
