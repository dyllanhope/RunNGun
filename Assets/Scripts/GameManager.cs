using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int enemyCount = 0;

    int currentScore = 0;

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public void SetEnemyCount(int count)
    {
        enemyCount = count;
    }

    public void KillEnemy()
    {
        enemyCount --;
    }

    public void IncreaseScore(int points)
    {
        currentScore += points;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
