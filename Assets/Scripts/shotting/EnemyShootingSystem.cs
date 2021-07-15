using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� ����� �� ����������� �� ������������ ������, �� ���� �� ������ ����������� �� ��� �� ����������� 
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
