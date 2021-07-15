using System.Collections;
using UnityEngine;

public class Pistol : Weapon
{
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

        float x = Random.Range(-stats.Spread, stats.Spread);
        float y = Random.Range(-stats.Spread, stats.Spread);

        // –асчет вектора направлени€ и прибавка разброса
        direction = (targetPoint - startPoint.position);
        direction += new Vector3(x, y, 0) * direction.magnitude;

        GameObject bulletGM = base.GetBullet();
        bulletGM.transform.position = startPoint.position;

        Bullet bullet = bulletGM.GetComponent<Bullet>();
        bullet.Shoot(direction.normalized * stats.SpeedOfBullet, startPoint.position, this);
        clip--;

        yield return new WaitForSeconds(stats.RateOfFire);
        isShooting = false;
    }
}
