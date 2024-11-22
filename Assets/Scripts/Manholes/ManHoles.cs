using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManHoles : MonoBehaviour
{
    public float damageMeter = 100f;
    float degradeRate = 8f;
    float repairReward = 5;
    float wearAndTear = 6;
    public int manHoleLevel = 1;
    public int upgradeCost;
    public int RepairCost;
    Slider damageMeterSlider;
    Canvas viewCanvas;
    bool degrade = true;

    void Start()
    {
        upgradeCost = 2;
        RepairCost = 1;
        damageMeterSlider = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Slider>();
        viewCanvas = gameObject.transform.GetChild(0).GetComponent<Canvas>();
        GameManager.instance.population += 200;
        SliderManager.instance.addManHoleToList(gameObject);
    }

    void Update()
    {
        DamageMeterUpdater();
        if(degrade == true && damageMeter > 0)
        {
            StartCoroutine(manHoleDeterioration());
            degrade = false;
        }
        if(damageMeter < 0)
        {
            damageMeter = 0;
        }
    }
    void DamageMeterUpdater()
    {
        viewCanvas.transform.LookAt(Camera.main.transform);
        damageMeterSlider.value = damageMeter;
    }
    IEnumerator manHoleDeterioration()
    {
        yield return new WaitForSeconds(degradeRate);
        damageMeter -= wearAndTear;
        degrade = true;
    }
    public void RepairManHole()
    {
        damageMeter = 100f;
        StopCoroutine(manHoleDeterioration());
        degrade = true;
        //give player Money after repair
        GameManager.instance.coins += (int)repairReward;
    }
    public void UpgradeManHole()
    {
        GameManager.instance.UseCoins(upgradeCost);
        manHoleLevel++;
        degradeRate += 3;
        if(wearAndTear > 3)
        {
            wearAndTear -= 1;
        }
        RepairCost += 3;
        repairReward += 5;
        upgradeCost += 5;
        //increase population
        GameManager.instance.population += 250;
    }
}
