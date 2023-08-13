using System;
using UnityEngine;

public class PlayerHealth : EntityHealth
{
    [SerializeField] private HealthUI healthUI;

    protected override void DisplayOfHealth()
    {
        healthUI.UpdateHealthSlider((float)_health / _maxHealth);
    }
}
