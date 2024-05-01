using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] List<GameObject> powerUpList;

    float bulletSizeMultiplier = 1f;

    public void IncreaseBulletSizeMultiplier(float addedMultiplier)
    {
        bulletSizeMultiplier += addedMultiplier;
        Debug.Log(bulletSizeMultiplier);
    }

    public float GetBulletSizeMultiplier()
    {
        return bulletSizeMultiplier;
    }
}