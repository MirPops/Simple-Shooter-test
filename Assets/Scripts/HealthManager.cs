using UnityEngine;

public class HealthManager : MonoBehaviour, IDamagable
{
    public event System.Action OnDead;
    public int Health { get => health; }
    private int health = 100;

    public void GetDamage(int damage)
    {
        Debug.Log($"{name} get damage {damage}, now {health - damage}");
        health -= damage;
        if (health < 1)
        {
            health = 0;
            OnDead?.Invoke();
        }
    }
}
