using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;

    GameManager gameManager;

    int enemyCount = 0;
    int currentWaveIndex = 0;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        if (enemyCount == 0)
        {
            var spawnPoints = waveConfigs[currentWaveIndex].GetEnemySpawnsList();
            var enemyList = waveConfigs[currentWaveIndex].GetEnemyList();

            //set global enemy count tracker
            gameManager.SetEnemyCount(waveConfigs[currentWaveIndex].GetEnemyCount());
            enemyCount = waveConfigs[currentWaveIndex].GetEnemyCount();

            foreach (var spawn in spawnPoints)
            {
                foreach (var enemy in enemyList)
                {
                    Instantiate(enemy, spawn.transform.position, Quaternion.identity);
                }
            }

            //reset the current wave index when we have completed all the waves to start over for now
            currentWaveIndex = (currentWaveIndex + 1) > waveConfigs.Count - 1 ? 0 : currentWaveIndex + 1;
        }

        enemyCount = gameManager.GetEnemyCount();
    }
}
