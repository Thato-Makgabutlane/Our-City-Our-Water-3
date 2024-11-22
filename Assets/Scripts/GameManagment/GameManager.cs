using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] TMP_Text coinTXT;
    public int TruckCount;
    public int coins;
    public bool Generateincome = true;
    public int population;

    void Awake()
    {
        instance = this;
        if(tutorialManager.instance != null)
        {
            coins = 1000;
        }
        else
        {
            coins = 60;
        }
        coinTXT.text = "R " + coins;

    }

    
    void Update()
    {
        coinTXT.text = "R " + coins;
        if (Generateincome == true)
        {
            StartCoroutine(GainIncome());
            Generateincome = false;
        }
        GameOver();
        DevCheats();
    }
    public void UseCoins(int amount)
    {
        coins -= amount;
    }
    
    IEnumerator GainIncome()
    {
        yield return new WaitForSeconds(20);
        coins += population / ((100 - SliderManager.instance.HappinessMeter) * SliderManager.instance.ManHolesList.Count);
        Generateincome = true;
    }
    void GameOver()
    {
        if(SliderManager.instance.HappinessMeter <= 10)
        {
            MenuScript.instance.GameOver();
        }
    }
    public void AddToTruckCount()
    {
        TruckCount++;
    }

    public void DevCheats()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            population += 1000;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            coins += 50;
        }
    }
}
