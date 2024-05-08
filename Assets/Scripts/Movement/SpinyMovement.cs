using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpinyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletDelay = 0.2f;

    Rigidbody2D myRigidBody2D;
    Vector2 moveInput;
    float facingAngle;

    PowerUpManager powerUpManager;

    [Header("Firing Bullet")]
    [SerializeField] float spreadAngle = 90f;
    bool isFiring = false;
    Coroutine firingCoroutine;
    public Transform firePoint;

    void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        powerUpManager = FindObjectOfType<PowerUpManager>();
    }

    private void Start()
    {
        powerUpManager.SetInitialFireRate(bulletDelay);
    }

    void FixedUpdate()
    {
        bulletDelay = powerUpManager.GetFireRateTime();
        Move();
        FaceMouse();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Move()
    {
        // Calculate velocity based on move input
        Vector2 playerVelocity = moveInput * movementSpeed;

        // Set the velocity directly
        myRigidBody2D.velocity = playerVelocity;
    }

    void FaceMouse()
    {
        // Get the mouse position in world coordinates and subtract the position of Spiny for the direction vector
        Vector3 lookDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // Calculate the angle in degrees
        facingAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        // Rotate the Rigidbody2D to face the mouse
        myRigidBody2D.rotation = facingAngle;
    }

    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
        if (isFiring)
        {
            if (firingCoroutine == null)
            {
                firingCoroutine = StartCoroutine(FireBullets());
            }
        }
        else
        {
            if (firingCoroutine != null)
            {
                StopCoroutine(firingCoroutine);
                firingCoroutine = null;
            }
        }
    }

    public Vector3 GetPlayerPos()
    {
        return transform.position;
    }

    IEnumerator FireBullets()
    {
        while (true)
        {
            var numberOfBullets = powerUpManager.GetBulletCount();
            float angleStep = spreadAngle / numberOfBullets;
            float aimingAngle = facingAngle + 90;
            float centeringOffset = (spreadAngle / 2) - (angleStep / 2); //offsets every projectile so the spread is  

            for (int i = 0; i < numberOfBullets; i++)
            {
                float currentBulletAngle = angleStep * i;

                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));
                GameObject bulletFired = Instantiate(bullet, transform.position, rotation);
                bulletFired.GetComponent<Bullet>().bulletDirection = rotation * Vector2.down;
            }
            yield return new WaitForSeconds(bulletDelay);
        }
    }
}
