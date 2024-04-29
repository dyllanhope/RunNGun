using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyList;
    [SerializeField] Transform spawnPoints;

    public List<GameObject> GetEnemyList()
    {
        return enemyList;
    }

    public int GetEnemyCount()
    {
        return enemyList.Count * GetSpawnCount();
    }

    public List<Transform> GetEnemySpawnsList()
    {
        List <Transform> spawnList = new List <Transform>();
        foreach (Transform spawnPoint in spawnPoints)
        {
            spawnList.Add(spawnPoint);
        }
        return spawnList;
    }

    int GetSpawnCount()
    {
        return spawnPoints.childCount;
    }
}
