using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI enemyCountText;

    int enemyCount = 0;

    int currentWave = 0;

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public void SetEnemyCount(int count)
    {
        enemyCount = count;
        enemyCountText.text = "Enemies: " + enemyCount.ToString("000");
    }

    public void KillEnemy()
    {
        enemyCount--;
        enemyCountText.text = "Enemies: " + enemyCount.ToString("000");
    }
    public void IncreaseCurrentWave()
    {
        currentWave++;
    }
    public int GetCurrentWave()
    {
        return currentWave;
    }

    public void ResetGame()
    {
        enemyCount = 0;
        currentWave = 1;
    }
}
