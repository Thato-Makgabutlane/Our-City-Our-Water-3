using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public static MenuScript instance;
    [SerializeField] GameObject gameScreen,gameOverScreen,popUpPanel;
    [SerializeField] GameObject SelectingManager;
    GameObject temp;
    [SerializeField] TMP_Text WarningTxt;
    [SerializeField] TMP_Text populationTxt;
    float warnintTxtTimer = 3;
    float warnintTxtTimerReset;
    #region Pop Up Panel Variables
    [SerializeField] TMP_Text LevelTXT;
    [SerializeField] TMP_Text HealthTXT;
    [SerializeField] TMP_Text UpgradeCostTXT;
    [SerializeField] TMP_Text RepairCostTXT;
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        instance = this;
        gameScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        popUpPanel.SetActive(false);
        WarningTxt.gameObject.SetActive(false);
        warnintTxtTimerReset = warnintTxtTimer;
    }
    //Gundo edit
    private void Start()
    {
        StartCoroutine(lateStart());
    }
    

    private void Update()
    {
        if(WarningTxt.gameObject.activeSelf == true)
        {
            warnintTxtTimer -= Time.deltaTime;
            if(warnintTxtTimer <= 0)
            {
                WarningTxt.gameObject.SetActive(false);
                warnintTxtTimer = warnintTxtTimerReset;
            }
        }
        populationTxt.text = "" + GameManager.instance.population;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }
    public void restartButton()
    {
        SRC.instance.ButtonPress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackToMenu()
    {
        SRC.instance.ButtonPress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void BackTo2DView()
    {
        SRC.instance.ManHolePress();
        if (tutorialManager.instance != null)
        {
            SRC.instance.ManHolePress();
            tutorialManager.instance.Snapped = true;
        }
        Camera.main.transform.rotation = Quaternion.Euler(90,0,0);
    }
    #region Pop Up Panel
    public void OpenPopUpPanel()
    {
        Time.timeScale = 0f;
        Camera.main.gameObject.GetComponent<Cam>().enabled = false;
        temp = Selecting.Instance.placeholder;
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        popUpPanel.SetActive(true);
        SRC.instance.ButtonPress();
        if (tutorialManager.instance != null && tutorialManager.instance.popUpIndex == 13)
        {
            tutorialManager.instance.ManHoleClickedForRepair = true;
        }
        if (tutorialManager.instance != null && tutorialManager.instance.popUpIndex == 16)
        {
            tutorialManager.instance.ManHoleClickedForUpgrade = true;
        }

        //populating Pop Up Screen
        LevelTXT.text = "Level: " + temp.GetComponent<ManHoles>().manHoleLevel;
        HealthTXT.text = "Condition:  " + temp.GetComponent<ManHoles>().damageMeter + "%";
        UpgradeCostTXT.text = "Upgrade Cost: " + temp.GetComponent<ManHoles>().upgradeCost;
        RepairCostTXT.text = "Repair Cost: " + temp.GetComponent<ManHoles>().RepairCost;
    }
    public void Upgrade()
    {
        if (tutorialManager.instance != null && tutorialManager.instance.popUpIndex == 17)
        {
            SRC.instance.ManHolePress();
            tutorialManager.instance.Upgraded = true;
        }
        if (GameManager.instance.coins >= temp.GetComponent<ManHoles>().upgradeCost)
        {
            SRC.instance.ManHolePress();
            temp.GetComponent<ManHoles>().UpgradeManHole();
        }
        else
        {
            WarningTxt.gameObject.SetActive(true);
            WarningTxt.text = "Not enough money to upgrade";
        }

        Time.timeScale = 1f;
        Camera.main.gameObject.GetComponent<Cam>().enabled = true;
        gameScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        popUpPanel.SetActive(false);
    }
    public void repair()
    {
        if (Station.instance.whiteCellQueue.Count == 0)
        {
            WarningTxt.gameObject.SetActive(true);
            WarningTxt.text = "Not enough Units available";
        }
        else if (Station.instance.whiteCellQueue.Count > 0 && GameManager.instance.coins >= temp.GetComponent<ManHoles>().RepairCost)
        {
            GameManager.instance.UseCoins(temp.GetComponent<ManHoles>().RepairCost);
            Station.instance.SendOut(temp);
            if (tutorialManager.instance != null && tutorialManager.instance.popUpIndex == 14)
            {
                SRC.instance.ManHolePress();
                tutorialManager.instance.TruckSent = true;
            }
        }
        else if(Station.instance.whiteCellQueue.Count > 0 && GameManager.instance.coins < temp.GetComponent<ManHoles>().RepairCost)
        {
            WarningTxt.gameObject.SetActive(true);
            WarningTxt.text = "Not enough money for the repair";
        }
        else
        {
            WarningTxt.gameObject.SetActive(true);
            WarningTxt.text = "Not enough Units available or coins for new Unit";
        }
        Time.timeScale = 1f;
        Camera.main.gameObject.GetComponent<Cam>().enabled = true;
        gameScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        popUpPanel.SetActive(false);
    }
    public void Close()
    {
        Time.timeScale = 1f;
        Camera.main.gameObject.GetComponent<Cam>().enabled = true;
        gameScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        popUpPanel.SetActive(false);
        SRC.instance.ButtonPress();
    }
    #endregion

    IEnumerator lateStart()
    {
        yield return new WaitForSeconds(0.2f);
        SRC.instance.BusyCity();
    }
}
