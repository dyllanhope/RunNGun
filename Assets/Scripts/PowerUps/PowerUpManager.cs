using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] List<GameObject> powerUpList;

    float bulletSizeMultiplier = 1f;
    float fireRateTime = 0f;
    int bulletCount = 1;

    #region Bullet size Code
    public void IncreaseBulletSizeMultiplier(float addedMultiplier)
    {
        bulletSizeMultiplier += addedMultiplier;
    }

    public float GetBulletSizeMultiplier()
    {
        return bulletSizeMultiplier;
    }
    #endregion

    #region Fire Rate Code
    public void SetInitialFireRate(float initialFireRate)
    {
        fireRateTime = initialFireRate;
    }

    public void DecreaseFireRateTime(float fireRateDecrease)
    {
        if (fireRateTime > 0)
        {
            fireRateTime -= fireRateDecrease;
        }
    }

    public float GetFireRateTime()
    {
        return fireRateTime;
    }
    #endregion

    #region Bullet count Code
    public void increaseBulletCount(int amount)
    {
        bulletCount += amount;
    }

    public int GetBulletCount()
    {
        return bulletCount;
    }
    #endregion

    public void SpawnRandomPowerUp()
    {
        var randomIndex = Random.Range(0, powerUpList.Count);
        Instantiate(powerUpList[randomIndex], transform.position, Quaternion.identity);
    }
}