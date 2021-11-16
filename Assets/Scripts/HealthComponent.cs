using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public HealthData HealthData;

    private int MaxHealth;
    private int HealthRegenPerSec;
    private int CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            if (value <= 0)
            {
                _currentHealth = 0;
                Die();
            }
            else
            {
                _currentHealth = value;
            }
        }
    }
    public int _currentHealth;

    private float HealthRegenTimer
    {
        get { return _healthRegenTimer; }
        set
        {
            if (value >= 1)
            {
                CurrentHealth = Mathf.Min(HealthRegenPerSec + CurrentHealth, MaxHealth);
                _healthRegenTimer = 0f;
            }
            else
            {
                _healthRegenTimer = value;
            }
        }
    }
    private float _healthRegenTimer;
    public void Awake()
    {
        MaxHealth = HealthData.MaxHealth;
        HealthRegenPerSec = HealthData.HealthRegenPerSec;
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        RegenHealth();
    }

    public void DealDamage(int damage)  // TODO Hiljem võib-olla vaja arvestada armoriga
    {
        CurrentHealth -= damage;
    }

    private void Die()  // TODO Implement death
    {
        throw new System.NotImplementedException();
    }

    private void RegenHealth()
    {
        if (CurrentHealth == MaxHealth) { return; }
        HealthRegenTimer += Time.deltaTime;
    }
}
