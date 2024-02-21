using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetInt("Slider", 5);
    }

    public void TakeDamage(float dmg)
    {
        slider.value -= dmg;
        PlayerPrefs.SetInt("Slider", (int)slider.value);
    }
}
