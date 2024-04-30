using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] bool isEnemy = true;
    [SerializeField] int points = 20;

    GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (isEnemy)
        { 
            gameManager.KillEnemy();
            gameManager.IncreaseScore(points);
        }
        Destroy(gameObject);
    }
}
