using System.Collections;
using UnityEngine;

public class Enemy : CharacterManager
{
    [SerializeField] private float stepDelay = 0.1f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    public EnemyShootingSystem shootingSystem;
    private Transform target;


    private void Start()
    {
        FindTarget();
    }

    // Ищет игрока вокруг себя 
    private void FindTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 20f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("Player"))
            {
                target = colliders[i].transform;
                StartCoroutine(FollowTargetRoutine());
                StartCoroutine(shootingSystem.StartShoot(target));
                break;
            }
        }
    }

    // Следует за игроком
    private IEnumerator FollowTargetRoutine()
    {
        while (target)
        {
            yield return new WaitForSeconds(stepDelay);
            transform.LookAt(target);
            rb.velocity = (target.position - transform.position) * speed;
        }
    }
}
