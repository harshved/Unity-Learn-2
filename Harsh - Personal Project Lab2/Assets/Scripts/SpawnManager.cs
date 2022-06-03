using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;

    private float zEnemySpawn = 12.0f;
    private float xSpawnRange = 16.0f;
    private float zPowerupRange = 10.0f;
    private float ySpawn = 0.75f;

    private float powerupSpawnTime = 5.0f;
    private float enemySpawnTime = 1.0f;
    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", startDelay, enemySpawnTime);                
        InvokeRepeating("spawnPowerup", startDelay, powerupSpawnTime);                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnpos = new Vector3(randomX, ySpawn, zEnemySpawn);
        Instantiate(enemies[randomIndex], spawnpos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void spawnPowerup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(0, zPowerupRange);

        Vector3 spawnpos = new Vector3(randomX, ySpawn, randomZ);
        Instantiate(powerup, spawnpos, powerup.gameObject.transform.rotation);
    }
}
