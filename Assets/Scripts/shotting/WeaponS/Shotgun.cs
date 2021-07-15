using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int bulletsPerShot;

    public override IEnumerator Shoot(Transform startPoint)
    {
        if (isShooting || isReloading)
            yield break;

        if (clip == 0)
        {
            StartCoroutine(Reload());
            yield break;
        }

        isShooting = true;

        Vector3 targetPoint, direction;

        Ray ray = new Ray(transform.position, transform.position + transform.forward * 100);

        if (Physics.Raycast(ray, out RaycastHit hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(50);

        // Стреляет бробью
        for (int i = 0; i < bulletsPerShot; i++)
        {
            float x = Random.Range(-stats.Spread, stats.Spread);
            float y = Random.Range(-stats.Spread, stats.Spread);

            // Расчет вектора направления и прибавка разброса
            direction = (targetPoint - startPoint.position);
            direction += new Vector3(x, y, 0) * direction.magnitude;

            GameObject bulletGM = base.GetBullet();
            bulletGM.transform.position = startPoint.position;

            Bullet bullet = bulletGM.GetComponent<Bullet>();
            bullet.Shoot(direction.normalized * stats.SpeedOfBullet, startPoint.position, this);
        }
        clip--;

        yield return new WaitForSeconds(stats.RateOfFire);
        isShooting = false;
    }
}
