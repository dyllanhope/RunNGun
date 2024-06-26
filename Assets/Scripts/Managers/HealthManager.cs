using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] int health = 50;
    [SerializeField] bool isEnemy = true;
    [SerializeField] Slider healthSlider;

    [Header("Points")]
    [SerializeField] int points = 20;

    [Header("Particles")]
    [SerializeField] ParticleSystem deathParticles;

    [Header("Camera Settings")]
    CinemachineImpulseSource impulseSource;

    GameManager gameManager;
    LevelManager levelManager;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
        levelManager = FindObjectOfType<LevelManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    private void Start()
    {
        if (!isEnemy)
        {
            healthSlider.maxValue = health;
            healthSlider.value = health;
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (!isEnemy)
        {
            healthSlider.value = health;
        }
    }
    void Die()
    {
        if (isEnemy)
        {
            gameManager.KillEnemy();
            scoreKeeper.IncreaseScore(points);
            PlayDeathParticles();
        }
        else
        {
            impulseSource.GenerateImpulse(1);
            levelManager.LoadGameOverScene();
        }
        Destroy(gameObject);
    }

    void PlayDeathParticles()
    {
        ParticleSystem instance = Instantiate(deathParticles, transform.position, Quaternion.identity);
        instance.Play();
        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    }
}
