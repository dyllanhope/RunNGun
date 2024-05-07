using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10.0f;
    [SerializeField] int bulletDamage = 10;

    [SerializeField] ParticleSystem wallHitParticles;

    Rigidbody2D myRigidBody;
    SpinyMovement spinyMovement;

    public Vector3 bulletDirection { get; set; }

    PowerUpManager powerUpManager;
    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        spinyMovement = FindObjectOfType<SpinyMovement>();

        powerUpManager = FindObjectOfType<PowerUpManager>();
    }
    void Start()
    {
        myRigidBody.transform.position = spinyMovement.transform.position;

        SetBulletSize();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        myRigidBody.velocity = bulletDirection * bulletSpeed;
    }

    public void SetBulletDirection(Vector3 direction)
    {
        bulletDirection = direction;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<HealthManager>().TakeDamage(bulletDamage);
        }
        if (collision.gameObject.tag == "Wall")
        {
            //trigger particle system on wall hit
            ParticleSystem instance = Instantiate(wallHitParticles, transform.position, Quaternion.identity);
            instance.Play();
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
        Destroy(gameObject);
    }

    void SetBulletSize()
    {
        gameObject.transform.localScale = new Vector2(transform.localScale.x * powerUpManager.GetBulletSizeMultiplier(), transform.localScale.y * powerUpManager.GetBulletSizeMultiplier());
    }
}
