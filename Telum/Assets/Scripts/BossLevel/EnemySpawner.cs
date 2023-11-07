using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    public float spawnRadius = 5f;

    private float lastSpawnTime;

    void Start()
    {
        lastSpawnTime = Time.time;
    }

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnInterval)
        {
            SpawnEnemy();
            lastSpawnTime = Time.time;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}