using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TruckImageManager : MonoBehaviour
{
    public static TruckImageManager instance;
    //Truck Image List
    public List<GameObject> Trucks = new List<GameObject>();

    //White - When the truck is inside the building  
    //Gray - When the truck is out on repair
    [SerializeField] Sprite WhiteTruck;
    [SerializeField] Sprite GrayTruck;

    public int TrucksAvailable;
    public int TrucksOutside;
    public int TrucksInside;

    private void Awake()
    {
        instance = this;
    }
    public void ChangeImage()
    {
        if(TrucksAvailable == 1)
        {
            Trucks[0].GetComponent<Image>().sprite = WhiteTruck;
        }
        else if(TrucksAvailable == 2)
        {
            Trucks[1].GetComponent<Image>().sprite = WhiteTruck;
        }
        else if(TrucksAvailable == 3)
        {
            Trucks[2].GetComponent<Image>().sprite = WhiteTruck;
        }
        else if (TrucksAvailable == 4)
        {
            Trucks[3].GetComponent<Image>().sprite = WhiteTruck;
        }
        else if (TrucksAvailable == 5)
        {
            Trucks[4].GetComponent<Image>().sprite = WhiteTruck;
        }
    }
}
