using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private Weapon Owner;
    private Vector3 startPoint;
    private int damage;

    public void Shoot(Vector3 velocity, Vector3 startPoint, Weapon weapon)
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(velocity, ForceMode.Impulse);
        this.damage = weapon.baseDamage;

        Owner = weapon;
        this.startPoint = startPoint;
        StartCoroutine(RangeCalcRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.GetDamage(damage);
        }
        if (!other.isTrigger)
            Owner.DestoyBullet(gameObject);
    }

    private IEnumerator RangeCalcRoutine()
    {
        while (gameObject)
        {
            yield return new WaitForSeconds(0.25f);
            if (Vector3.Distance(startPoint, transform.position) > Owner.range)
                Owner.DestoyBullet(gameObject);
        }
    }
}
