using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitShot : MonoBehaviour
{
    [SerializeField] int bulletIncreaseRate = 1;
    PowerUpManager powerUpManager;
    void Awake()
    {
        powerUpManager = FindObjectOfType<PowerUpManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        powerUpManager.increaseBulletCount(bulletIncreaseRate);
        Destroy(gameObject);
    }
}
