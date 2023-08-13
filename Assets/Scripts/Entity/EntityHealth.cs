using System;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField, Min(1)] protected int _maxHealth;

    public Action OnDead;

    protected int _health;
    public int HealthValue
    {
        get => _health;
        private set
        {
            if(value <= 0)
            {
                OnDead?.Invoke();
                _health = 0;
            }
            else if(value > _maxHealth)
            {
                _health = _maxHealth;
            }
            else
                _health = value;

            DisplayOfHealth();
        }
    }

    private void OnEnable()
    {
        HealthValue = _maxHealth;
    }

    public void SetDamage(int valueDamage)
    {
        HealthValue -= valueDamage;
    }
    public void Treat(int valueTrat)
    {
        HealthValue += valueTrat;
    }

    protected virtual void DisplayOfHealth() { }
}
