using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10.0f;
    [SerializeField] ParticleSystem wallHitParticles;

    Rigidbody2D myRigidBody;
    SpinyMovement spinyMovement;

    Vector3 bulletDirection;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        spinyMovement = FindObjectOfType<SpinyMovement>();
        myRigidBody.transform.position = spinyMovement.transform.position;
        bulletDirection = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;

        // Calculate the rotation angle based on the direction vector
        float angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        myRigidBody.velocity = bulletDirection * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            //you're working on the particles. They just aren't playing for some reason
            wallHitParticles.Play();
            Destroy(gameObject);
        }
    }
}
