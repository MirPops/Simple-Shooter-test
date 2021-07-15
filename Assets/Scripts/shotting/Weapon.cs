using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Базовый класс для всего оружия
public abstract class Weapon : MonoBehaviour
{
    public WeaponStats stats;
    protected int clip;
    protected bool isReloading = false, isShooting = false;
    private Stack<GameObject> bulletPull;

    private void Start()
    {
        bulletPull = new Stack<GameObject>();
        clip = stats.MaxClipAmount;
        print(clip);
    }

    public abstract IEnumerator Shoot(Transform startPoint);

    public virtual IEnumerator Reload()
    {
        if (isReloading)
            yield break;
        
        isReloading = true;
        yield return new WaitForSeconds(stats.TimeReload);
        clip = stats.MaxClipAmount;
        isReloading = false;
    }


    // Пул обьектов
    public void DestoyBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPull.Push(bullet);
    }

    protected GameObject GetBullet()
    {
        GameObject newBullet;
        if (bulletPull.Count < 1)
            newBullet = Instantiate(stats.Bullet);
        else
            newBullet = bulletPull.Pop();

        newBullet.SetActive(true);
        return newBullet;
    }
}
