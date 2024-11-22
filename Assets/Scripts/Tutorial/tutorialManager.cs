using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialManager : MonoBehaviour
{
    public static tutorialManager instance;
    [SerializeField] GameObject[] popUps;
    public int popUpIndex;
    private int controlsIndex;
    [SerializeField] float Timer = 3;

    public bool Snapped = false;
    public bool ManHoleClickedForRepair = false;
    public bool ManHoleClickedForUpgrade = false;
    public bool TruckSent = false;
    public bool Upgraded = false;
    bool once = false;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
        GameManager.instance.Generateincome = false;
    }
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                //popUps[i].SetActive(false);
            }
        }

        //Panning lesson
        if (controlsIndex == 0 && popUpIndex == 0)
        {
            if(Input.GetMouseButton(0))
            {
                Timer -= Time.deltaTime;
            }
            if(Timer <= 0)
            {
                controlsIndex++;
                popUpIndex++;
                Timer = 3;
                popUps[0].SetActive(false);
            }
            
        }
        //Orbit lesson
        if (controlsIndex == 1 && popUpIndex == 1)
        {
            if (Input.GetMouseButton(1))
            {
                Timer -= Time.deltaTime;
            }
            if (Timer <= 0)
            {
                controlsIndex++;
                popUpIndex++;
                Timer = 10;
                popUps[1].SetActive(false);
            }
        }
        //Snap lesson
        if (controlsIndex == 2 && popUpIndex == 2)
        {
            popUps[3].SetActive(true);
            if (Snapped)
            {
                popUps[2].SetActive(false);
                controlsIndex++;
                popUpIndex += 2;
            }
        }
        //Introduce Money
        if (popUpIndex == 4)
        {
            popUps[5].SetActive(true);
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                popUps[4].SetActive(false);
                controlsIndex++;
                popUpIndex += 2;
                Timer = 10;
            }
        }
        //Introduce Trucks
        if (popUpIndex == 6)
        {
            popUps[7].SetActive(true);
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                popUps[6].SetActive(false);
                GameManager.instance.Generateincome = true;
                controlsIndex++;
                popUpIndex += 2;
                Timer = 10;
            }
        }
        //Introduce Happiness Meter
        if (popUpIndex == 8)
        {
            popUps[9].SetActive(true);
            popUps[10].SetActive(true);
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                popUps[8].SetActive(false);
                controlsIndex++;
                popUpIndex += 3;
                Timer = 10;
            }
        }
        //Introduce Buy Truck
        if (popUpIndex == 11)
        {
            popUps[12].SetActive(true);
            if (GameManager.instance.TruckCount > 0)
            {
                popUps[11].SetActive(false);
                controlsIndex++;
                popUpIndex += 2;
            }
        }
        //Click ManHole Lesson
        if (popUpIndex == 13)
        {
            if (ManHoleClickedForRepair)
            {
                popUps[13].SetActive(false);
                controlsIndex++;
                popUpIndex ++;
            }
        }
        //Fix Manhole Lesson
        if (popUpIndex == 14)
        {
            if (TruckSent)
            {
                popUps[14].SetActive(false);
                controlsIndex++;
                popUpIndex++;
            }
        }
        //watching truck fix
        if (popUpIndex == 15)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                popUps[15].SetActive(false);
                controlsIndex++;
                popUpIndex++;
                Timer = 10;
            }
        }
        //Upgrade Lesson
        if (popUpIndex == 16)
        {
            if (Station.instance.AUnits > 0)
            {
                popUps[16].SetActive(true);
                if (ManHoleClickedForUpgrade)
                {
                    popUps[16].SetActive(false);
                    controlsIndex++;
                    popUpIndex++;
                }
            }
            else
            {
                popUps[16].SetActive(false);
            }
        }
        if (popUpIndex == 17)
        {
            if (Upgraded)
            {
                popUps[17].SetActive(false);
                controlsIndex++;
                popUpIndex++;
            }
        }
        if (popUpIndex == 18)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                popUps[18].SetActive(false);
                controlsIndex++;
                popUpIndex++;
                Timer = 10;
            }
        }
        if (popUpIndex == 19)
        {
            if(!once)
            {
                Timer -= Time.deltaTime;
            }
            else
            {
                popUps[19].SetActive(false);
            }
            if (Timer <= 0)
            {
                popUps[19].SetActive(false);
                Timer = 10;
                once = true;
            }
            if(GameManager.instance.population >= 3000)
            {
                controlsIndex++;
                popUpIndex++;
            }
        }
        if (popUpIndex == 20)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                popUps[20].SetActive(false);
                controlsIndex++;
                popUpIndex++;
                Timer = 10;
            }
        }
        if (popUpIndex == 21)
        {
            if (GameManager.instance.TruckCount >= 5)
            {
                popUps[21].SetActive(false);
                controlsIndex++;
                popUpIndex++;
                Timer = 10;
            }
        }
        //End
        if (popUpIndex == 22)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                popUps[22].SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
