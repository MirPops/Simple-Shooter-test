using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGun : Weapon, IDoDamage
{
    [SerializeField] private float damageRate;
    [SerializeField] private float duration;

    // Метод для постепенного нанесения урона
    public IEnumerator DoDamage(HealthManager healthManager, Bullet bullet)
    {
        float dur = 0;
        bullet.rb.velocity = Vector3.zero;
        while (dur < duration)
        {
            healthManager.GetDamage(stats.BaseDamage);
            dur += damageRate;
            yield return new WaitForSeconds(damageRate);
        }
        DestoyBullet(bullet.gameObject);
    }

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

        RaycastHit hit;
        Vector3 targetPoint, direction;

        Ray ray = new Ray(transform.position, transform.position + transform.forward * 100);

        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(50);

        float x = Random.Range(-stats.Spread, stats.Spread);
        float y = Random.Range(-stats.Spread, stats.Spread);

        direction = (targetPoint - startPoint.position);
        direction += new Vector3(x, y, 0) * direction.magnitude;

        GameObject bulletGM = base.GetBullet();
        bulletGM.transform.position = startPoint.position;

        Bullet bullet = bulletGM.GetComponent<Bullet>();
        bullet.Shoot(direction.normalized * stats.SpeedOfBullet, startPoint.position, this, this);
        clip--;

        yield return new WaitForSeconds(stats.RateOfFire);
        isShooting = false;
    }
}
