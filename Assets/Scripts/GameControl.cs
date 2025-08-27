using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private PlayerControl _playerControl;
    [SerializeField] private Gun _gun;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private UIManager _uIManager;

    private void Start()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        _playerControl.ShootPressed += Shoot;
        _playerHealth.HealthChanged += ChangeHealth;
    }

    private void ChangeHealth(float points)
    {
        _uIManager.ChangeHealthText(points);
    }

    private void Shoot()
    {
        _gun.Shoot();
    }
}
