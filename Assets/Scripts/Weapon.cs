using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] public int baseDamage;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected float timeReload;
    [SerializeField] protected float rateOfFire;
    [SerializeField] public float range;
    [SerializeField] protected float spread;
    [SerializeField] protected int maxClipAmount;
    [SerializeField] protected float speedOfBullet;
    protected int clip;

    protected bool isReloading = false, isShooting = false;

    private Stack<GameObject> bulletPull;

    private void Start()
    {
        bulletPull = new Stack<GameObject>();
        clip = maxClipAmount;
    }

    public abstract IEnumerator Shoot(Transform startPoint, Camera camera);

    public virtual IEnumerator Reload()
    {
        if (isReloading)
            yield break;
        
        isReloading = true;
        yield return new WaitForSeconds(timeReload);
        clip = maxClipAmount;
        isReloading = false;
    }

    protected GameObject GetBullet()
    {
        GameObject newBullet;
        if (bulletPull.Count < 1)
            newBullet = Instantiate(bullet);
        else
            newBullet = bulletPull.Pop();

        newBullet.SetActive(true);
        return newBullet;
    }

    public void DestoyBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPull.Push(bullet);
    }
}
