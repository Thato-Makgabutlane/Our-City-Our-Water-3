using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainScreem, controlesScreen;

    //Gundo edit: its to play the audio as soon as this script starts
    
    private void Start()
    {
        StartCoroutine(LateStart());
    }
    // Going to connect the sound and buttons
    public void StartGame()
    {
        SRC.instance.ButtonPress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Controles()
    {
        SRC.instance.ButtonPress();
        mainScreem.SetActive(false);
        controlesScreen.SetActive(true);
    }
    public void Close()
    {
        SRC.instance.ButtonPress();
        mainScreem.SetActive(true);
        controlesScreen.SetActive(false);
    }
    public void QuitGame()
    {
        SRC.instance.ButtonPress();
        Application.Quit();
    }
    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.05f);
        SRC.instance.BGM();
    }
}
