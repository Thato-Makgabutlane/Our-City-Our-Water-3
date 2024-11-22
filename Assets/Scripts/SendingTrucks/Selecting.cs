using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Selecting : MonoBehaviour
{
    public static Selecting Instance;
    public Vector3 ScreenPos;
    public LayerMask LayerMask;
    public GameObject temp, placeholder;
    private void Awake()
    {
        Instance = this;
        
    }
    private void Update()
    {
        
        ScreenPos = Input.mousePosition;
        Debug.DrawRay(transform.position, ScreenPos - transform.position, Color.red);
        Ray ray = Camera.main.ScreenPointToRay(ScreenPos);
        if (temp != null)//populating placeholder
        {
            placeholder = temp;
        }
        if (Physics.Raycast(ray, out RaycastHit meshr, 1000000, LayerMask))//shot ray
        {
            if (placeholder != null)
            {
                if (placeholder != meshr.transform.gameObject)
                {
                    //placeholder.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            temp = meshr.transform.gameObject;
        }
        else
        {
            if (placeholder != null)
            {
                //placeholder.GetComponent<MeshRenderer>().enabled = false;
                placeholder = null;
            }
        }
        if (Input.GetMouseButtonDown(0) && placeholder != null)//spawn cell on click
        {
           MenuScript.instance.OpenPopUpPanel();
        }
    }
}
