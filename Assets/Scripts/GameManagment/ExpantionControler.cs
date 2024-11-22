using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpantionControler : MonoBehaviour
{
    [SerializeField] List<GameObject> Areas = new List<GameObject>();
    [SerializeField] GameObject stationMovePoint1, stationMovePoint2;
    [SerializeField] GameObject truckStation;
    Vector3 offset = new Vector3(0, 0.5f, 0);
    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.population >= 3000)
        {
            Areas[0].gameObject.SetActive(true);
            truckStation.transform.position = stationMovePoint1.transform.position + offset;
        }
        if (GameManager.instance.population >= 6000)
        {
            Areas[1].gameObject.SetActive(true);
            truckStation.transform.position = stationMovePoint2.transform.position + offset;
        }
    }
}
