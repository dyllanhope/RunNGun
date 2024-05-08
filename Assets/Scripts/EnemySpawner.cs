using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    [SerializeField] Vector2 spawnBounds = new Vector2(20, 12);
    [SerializeField] ParticleSystem spawnParticles;

    GameManager gameManager;
    PowerUpManager powerUpManager;

    int enemyCount = 0;
    int currentWaveIndex = 1;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        powerUpManager = FindObjectOfType<PowerUpManager>();
    }

    void Update()
    {
        SpawnWave();
    }

    void SpawnWave()
    {
        if (enemyCount == 0)
        {
            //List of enemy types (currently 1 basic enemy)
            List<GameObject> enemyList = waveConfig.GetEnemyList();
            for (int i = 0; i < currentWaveIndex; i++)
            {
                Vector3 randomPos = GetRandomPositionInBounds();
                StartCoroutine(SpawnEnemy(enemyList, Random.Range(0, enemyList.Count), randomPos));
            }

            if (currentWaveIndex % 2 == 0)
            {
                powerUpManager.SpawnRandomPowerUp();
            }

            //set global enemy count tracker
            gameManager.SetEnemyCount(currentWaveIndex);

            currentWaveIndex++;
        }
        enemyCount = gameManager.GetEnemyCount();
    }

    IEnumerator SpawnEnemy(List<GameObject> enemyList, int randomIndex, Vector3 randomPos)
    {
        var instance = Instantiate(spawnParticles, transform.position + randomPos, Quaternion.identity);
        instance.Play();
        yield return new WaitForSeconds(instance.main.duration + instance.main.startLifetime.constantMax);
        Destroy(instance.gameObject);
        Instantiate(enemyList[randomIndex], transform.position + randomPos, Quaternion.identity);
    }

    Vector2 GetRandomPositionInBounds()
    {
        float randomX = Random.Range(-spawnBounds.x, spawnBounds.x);
        float randomY = Random.Range(-spawnBounds.y, spawnBounds.y);

        return new Vector2(randomX, randomY);
    }
}
