using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 100f;    
    public event Action<float> HealthChanged;

    private float _currentHealth;

    void Start()
    {
        _currentHealth = MaxHealth;
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        print($"Player has {_currentHealth} points of health.");
        HealthChanged?.Invoke(_currentHealth);
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
