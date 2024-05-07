using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;

    GameManager gameManager;
    PowerUpManager powerUpManager;

    int enemyCount = 0;
    int currentWaveIndex = 0;
    bool firstWave = true;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        powerUpManager = FindObjectOfType<PowerUpManager>();
    }

    void Update()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        if (enemyCount == 0)
        {

            if (!firstWave && currentWaveIndex == 0)
            {
                powerUpManager.SpawnRandomPowerUp();
            }

            var spawnPoints = waveConfigs[currentWaveIndex].GetEnemySpawnsList();
            var enemyList = waveConfigs[currentWaveIndex].GetEnemyList();

            //set global enemy count tracker
            gameManager.SetEnemyCount(waveConfigs[currentWaveIndex].GetEnemyCount());
            enemyCount = waveConfigs[currentWaveIndex].GetEnemyCount();

            foreach (var spawn in spawnPoints)
            {
                gameManager.IncreaseCurrentWave();
                foreach (var enemy in enemyList)
                {
                    Instantiate(enemy, spawn.transform.position, Quaternion.identity);
                }
            }

            //reset the current wave index when we have completed all the waves to start over for now
            currentWaveIndex = (currentWaveIndex + 1) > waveConfigs.Count - 1 ? 0 : currentWaveIndex + 1;

        }

        enemyCount = gameManager.GetEnemyCount();
        if (firstWave)
        {
            firstWave = !firstWave;
        }
    }

    public int GetWaveCount()
    {
        return waveConfigs.Count;
    }
}
