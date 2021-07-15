using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Базовый класс для системы стрельбы
public abstract class ShootingSystem : MonoBehaviour
{
    [SerializeField] protected Transform startPointBullet;

    protected abstract void Shoot();
    protected abstract void Reload();
}