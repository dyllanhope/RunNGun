using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] int health = 50;
    [SerializeField] bool isEnemy = true;

    [Header("Points")]
    [SerializeField] int points = 20;

    [Header("Particles")]
    [SerializeField] ParticleSystem deathParticles;

    [Header("Camera Settings")]
    CinemachineImpulseSource impulseSource;

    GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
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
            PlayDeathParticles();
        }
        else
        {
            impulseSource.GenerateImpulse(1);
        }
        Destroy(gameObject);
    }

    void PlayDeathParticles()
    {
        var instance = Instantiate(deathParticles, transform.position, Quaternion.identity);
        instance.Play();
        Destroy(instance, deathParticles.main.duration + deathParticles.main.startLifetime.constantMax);
    }
}
