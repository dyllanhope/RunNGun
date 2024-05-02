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

    public void DecreaseFireRateTime(float fireRateTime)
    {
        fireRateTime -= fireRateTime;
    }

    public float GetFireRateTime()
    {
        return fireRateTime;
    }
}