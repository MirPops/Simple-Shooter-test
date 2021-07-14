using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int bulletsPerShot;
    public override IEnumerator Shoot(Transform startPoint, Camera camera)
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

        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(50);

        for (int i = 0; i < bulletsPerShot; i++)
        {
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            direction = (targetPoint - startPoint.position);
            direction += new Vector3(x, y, 0) * direction.magnitude;

            GameObject bulletGM = base.GetBullet();
            bulletGM.transform.position = startPoint.position;

            Bullet bullet = bulletGM.GetComponent<Bullet>();
            bullet.Shoot(direction.normalized * speedOfBullet, startPoint.position, this);
        }
        clip--;

        yield return new WaitForSeconds(rateOfFire);
        isShooting = false;
    }
}
