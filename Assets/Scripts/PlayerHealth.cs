using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private Slider healthBar;
    public static event System.Action OnPlayerDead;
    public int Health { get => health; }
    private int health = 100;
    //private IDamagable damagable;

    private void Start()
    {
        healthBar.value = health;
    }

    public void GetDamage(int damage)
    {
        health -= damage;
        if (health < 1)
        {
            health = 0;
            OnPlayerDead?.Invoke();
        }
        UpDateValue();
    }

    private void UpDateValue()
    {
        healthBar.value = health;
    }

    //private void ChangeDamageType(IDamagable damagable)
    //{
    //    this.damagable = damagable;
    //}
}
