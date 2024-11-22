using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    [SerializeField] GameObject cell, spawnPoint;

    private void Awake()
    {
        instance = this;
    }
    public void spawnCell(GameObject x)
    {
        GameObject temp = Instantiate(cell, spawnPoint.transform.position, Quaternion.identity);
        temp.transform.parent = spawnPoint.transform;
        //temp.transform.gameObject.GetComponent<Trucks>().target = x;
        //Station.instance.lineUp(temp);
    }
}
