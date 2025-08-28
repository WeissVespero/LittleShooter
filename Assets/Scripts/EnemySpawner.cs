using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private PlayerControl _player;
    public float SpawnInterval = 2f;
    public float SpawnRadius = 10f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, SpawnInterval);
    }

    void SpawnEnemy()
    {
        GameObject enemyToSpawn = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)];

        Vector2 spawnPosition = GetRandomSpawnPosition();

        var enemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
        enemy.GetComponent<Enemy>().SetPlayerTransform(_player.transform);
    }

    Vector2 GetRandomSpawnPosition()
    {
        float randomAngle = Random.Range(0, 360f) * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        return (Vector2)Camera.main.transform.position + direction * SpawnRadius;
    }
}
