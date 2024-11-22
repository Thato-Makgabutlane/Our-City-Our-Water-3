using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Trucks : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    GameObject station;
    GameObject truckDisplay;
    [SerializeField] Sprite whiteTruck,GreyTruck;
    [SerializeField] float repairTime;
    float repairTimeReset;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        station = this.transform.parent.gameObject;
        repairTimeReset = repairTime;
        LinkToImage();
    }

    void Update()
    {
        if(target != null)
        {
            truckDisplay.GetComponent<Image>().sprite = GreyTruck;
            agent.destination = target.transform.position;
            if (Vector3.Distance(transform.position,target.transform.position) <= 2)
            {
                //What must happen when the truck gets there
                repairTime -= Time.deltaTime;
                if(repairTime <= 0)
                {
                    target.GetComponent<ManHoles>().RepairManHole();
                    repairTime = repairTimeReset;
                    target = null;
                }
                
            }
        }
        if(target == null)
        {
            agent.destination = station.transform.position;
            if(Vector3.Distance(transform.position, transform.parent.position) <= 2)
            {
                Station.instance.lineUp(gameObject);
                truckDisplay.GetComponent<Image>().sprite = whiteTruck;
                gameObject.SetActive(false);
            }
        }
        
    }
    void LinkToImage()
    {
        if(GameManager.instance.TruckCount == 1)
        {
            truckDisplay = GameObject.FindGameObjectWithTag("Image1");
        }
        else if (GameManager.instance.TruckCount == 2)
        {
            truckDisplay = GameObject.FindGameObjectWithTag("Image2");
        }
        else if (GameManager.instance.TruckCount == 3)
        {
            truckDisplay = GameObject.FindGameObjectWithTag("Image3");
        }
        else if (GameManager.instance.TruckCount == 4)
        {
            truckDisplay = GameObject.FindGameObjectWithTag("Image4");
        }
        else if (GameManager.instance.TruckCount == 5)
        {
            truckDisplay = GameObject.FindGameObjectWithTag("Image5");
        }
    }
}
