using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;

    private Weapon Owner;
    private Vector3 startPoint;
    private IDoDamage DoDamage;
    private int damage;


    public void Shoot(Vector3 velocity, Vector3 startPoint, Weapon weapon, IDoDamage doDamage = null)
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(velocity, ForceMode.Impulse);

        damage = weapon.stats.BaseDamage;
        DoDamage = doDamage;
        Owner = weapon;
        this.startPoint = startPoint;

        StartCoroutine(RangeCalcRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();
        if (damagable != null)
        {
            if (DoDamage != null)
            {
                StartCoroutine(DoDamage.DoDamage(other.GetComponent<HealthManager>(), this));
                return;
            }
            else
                damagable.GetDamage(damage);
        }
        if (!other.isTrigger)
            Owner.DestoyBullet(gameObject);
    }

    // ”ничтожаетс€ когда пройденное расстоние больше ренжа
    private IEnumerator RangeCalcRoutine()
    {
        while (gameObject)
        {
            yield return new WaitUntil(() => Vector3.Distance(startPoint, transform.position) > Owner.stats.Range);
            Owner.DestoyBullet(gameObject);
        }
    }
}
