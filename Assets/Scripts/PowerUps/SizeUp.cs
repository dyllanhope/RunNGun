using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUp : MonoBehaviour
{
    [SerializeField] float sizeMultiplier = 0.5f;

    PowerUpManager powerUpManager;
    void Awake()
    {
        powerUpManager = FindObjectOfType<PowerUpManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        powerUpManager.IncreaseBulletSizeMultiplier(sizeMultiplier);
    }
}
