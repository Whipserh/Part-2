using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthBar : MonoBehaviour
{
     public Slider slider;

    void Start()
    {
        slider.value = 100;
    }

    public void TakeDamage(float dmg)
    {
        slider.value -= dmg;
        //PlayerPrefs.SetInt("Slider", (int)slider.value);
    }
}