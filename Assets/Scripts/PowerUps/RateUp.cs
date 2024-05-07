using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUp : MonoBehaviour
{
    [SerializeField] float fireRateTime;

    PowerUpManager powerUpManager;

    private void Awake()
    {
        powerUpManager = FindObjectOfType<PowerUpManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        powerUpManager.DecreaseFireRateTime(fireRateTime);
        Destroy(gameObject);
    }
}
