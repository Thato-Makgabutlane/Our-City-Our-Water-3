using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRC : MonoBehaviour
{
    public static SRC instance;
    [Header("Background and SFX")]
    [SerializeField] AudioSource BackgroundMusic, SFX, Truck, Button;


    [Header("other Sounds")]
    [SerializeField] AudioClip backgroundMusic, sfx, button, truck, cityNoise, manhole;

    private void Awake()
    {
        instance = this;
    }
    public void BGM()
    {
        BackgroundMusic.clip = backgroundMusic;
        BackgroundMusic.Play();
        
    }

    public void SFXSound()
    {
        SFX.clip = sfx;
        SFX.Play();
    }


    public void ButtonPress()
    {
        Button.clip = button;
        Button.Play();
    }

    public void truckDeployed()
    {
        Truck.clip = truck;
        Truck.Play();
    }

    public void BusyCity()
    {
        BackgroundMusic.clip = cityNoise;
        BackgroundMusic.Play();
    }

    public void ManHolePress()
    {
        Button.clip = manhole;
        Button.Play();
    }
}
