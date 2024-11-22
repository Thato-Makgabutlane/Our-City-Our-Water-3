using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform target;
    public float hideDistance;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        var dir = target.position - transform.position;
        if (dir.magnitude < hideDistance)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }

        }
    }
}
