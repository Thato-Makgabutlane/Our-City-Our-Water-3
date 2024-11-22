using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderManager : MonoBehaviour
{
    //Handle Image Change
    [SerializeField] Sprite happy;
    [SerializeField] Sprite moderate;
    [SerializeField] Sprite angry;

    //Slider properties change
    [SerializeField] Image moodIndicatorImage;
    [SerializeField] Image fillColour;

    //UI editors
    [SerializeField] Slider HappinessMeterSlider;

    public int HappinessMeter = 100;
    public float changeSpeed; //Gradual Change in Slider
    public List<GameObject> ManHolesList = new List<GameObject>();
    public static SliderManager instance;
    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        HappinessCalculationAndMeterUpdater();
    }

    public void addManHoleToList(GameObject manHole)
    {
        ManHolesList.Add(manHole);
    }

    void HappinessCalculationAndMeterUpdater()
    {
        int avg = 0;
        for (int i = 0; i < ManHolesList.Count; i++)
        {
            avg += (int)ManHolesList[i].GetComponent<ManHoles>().damageMeter;
        }

        avg /= ManHolesList.Count;
        HappinessMeter = avg;
        HappinessMeterSlider.value = Mathf.MoveTowards(HappinessMeterSlider.value, HappinessMeter,changeSpeed * Time.deltaTime);

        if (HappinessMeter > 70)
        {
            moodIndicatorImage.sprite = happy;
            fillColour.color = Color.green;
        }
        else if (HappinessMeter >= 40)
        {
            moodIndicatorImage.sprite = moderate;
            fillColour.color = Color.yellow;
        }
        else if (HappinessMeter < 40)
        {
            moodIndicatorImage.sprite = angry;
            fillColour.color = Color.red;
        }

    }
}
