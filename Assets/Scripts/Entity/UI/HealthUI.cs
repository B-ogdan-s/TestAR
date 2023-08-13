using System;
using UnityEngine.UI;
using UnityEngine;

[Serializable]
public class HealthUI
{
    [SerializeField] private Slider _healthSlider;

    public void UpdateHealthSlider(float value)
    {
        _healthSlider.value = value;
    }
}

