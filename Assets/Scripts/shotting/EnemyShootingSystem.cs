using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Здесь можно не наследовать от абстрактного класса, но если бы проект разростался то это бы пригодилось 
public class EnemyShootingSystem : ShootingSystem
{
    [SerializeField] private Weapon[] weapons;
    private Weapon currentWeapon;

    public void SetWeapon()
    {
        currentWeapon = weapons[Random.Range(0, weapons.Length)];
        currentWeapon.gameObject.SetActive(true);
    }


    public IEnumerator StartShoot(Transform target)
    {
        while (target)
        {
            yield return new WaitForSeconds(currentWeapon.stats.RateOfFire);
            Shoot();
        }
    }


    protected override void Shoot()
        => StartCoroutine(currentWeapon.Shoot(startPointBullet));

    protected override void Reload()
        => StartCoroutine(currentWeapon.Reload());

    
}
