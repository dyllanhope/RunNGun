using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] List<GameObject> powerUpList;

    float bulletSizeMultiplier = 1f;
    float fireRateTime = 0f;

    public void IncreaseBulletSizeMultiplier(float addedMultiplier)
    {
        bulletSizeMultiplier += addedMultiplier;
    }

    public float GetBulletSizeMultiplier()
    {
        return bulletSizeMultiplier;
    }

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
}