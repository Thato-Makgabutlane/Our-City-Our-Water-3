using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Station : MonoBehaviour
{
    public TruckImageManager TruckImageManager;
    public static Station instance;
    public Queue<GameObject> whiteCellQueue = new Queue<GameObject>();
    public float AUnits;
    GameObject temp;

    private void Start()
    {
        instance = this;
        AUnits = whiteCellQueue.Count;
    }
    public void lineUp(GameObject x)
    {
        whiteCellQueue.Enqueue(x);
        AUnits = whiteCellQueue.Count;
    }
    public void SendOut(GameObject x)
    {
        temp = whiteCellQueue.Dequeue();
        AUnits = whiteCellQueue.Count;
        temp.transform.gameObject.GetComponent<Trucks>().target = x;
        temp.SetActive(true);
    }
}
