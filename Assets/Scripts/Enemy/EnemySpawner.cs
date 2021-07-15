using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float maxSpawnPosX;
    [SerializeField] private float maxSpawnPosY;
    [SerializeField] private float maxSpawnPosZ;
    [SerializeField] private float spawnRate;
    [SerializeField] private int enemiesAmount;

    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        for (int i = 0; i < enemiesAmount; i++)
        {
            yield return new WaitForSeconds(spawnRate);

            Vector3 spawnPos = new Vector3(Random.Range(-maxSpawnPosX, maxSpawnPosX),
            Random.Range(1, maxSpawnPosY),
            Random.Range(-maxSpawnPosZ, maxSpawnPosZ));

            GameObject enemyGM = Instantiate(enemyPrefab, spawnPos, Quaternion.identity, transform);
            enemyGM.GetComponent<Enemy>().shootingSystem.SetWeapon();
        }
    }
}
