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
    bool isFiring = false;
    Coroutine firingCoroutine;
    public Transform firePoint;
    public int numberOfBullets = 3;
    public float spreadAngle = 90f;

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
            //float startAngle = 0f /*facingAngle - spreadAngle / 2*/;
            //float angleStep = spreadAngle / (numberOfBullets);

            float angleStep = spreadAngle / numberOfBullets;
            float aimingAngle = facingAngle + 90;
            float centeringOffset = (spreadAngle / 2) - (angleStep / 2); //offsets every projectile so the spread is  

            //centered on the mouse cursor

            for (int i = 0; i < numberOfBullets; i++)
            {
                float currentBulletAngle = angleStep * i;

                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));
                GameObject bulletFired = Instantiate(bullet, transform.position, rotation);

                Rigidbody2D rb = bulletFired.GetComponent<Rigidbody2D>();
                rb.AddForce(bulletFired.transform.right * 15, ForceMode2D.Impulse);
            }
            //for (var i = 0; i < numberOfBullets; i++)
            //{
            //float angle = startAngle + i * angleStep;
            //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
            //Vector3 direction = rotation * transform.forward;

            //GameObject bulletFired = Instantiate(bullet, transform.position, Quaternion.identity);
            ////bulletFired.GetComponent<Bullet>().SetBulletDirection(direction);
            //Rigidbody2D bulletRB = bulletFired.GetComponent<Rigidbody2D>();
            //if (bulletRB != null)
            //{
            //    bulletRB.velocity = direction.normalized * 15;
            //    Debug.Log(bulletRB.velocity);
            //}


            //float projectileDirXPosition = transform.position.x + Mathf.Sin((startAngle * Mathf.PI) / 45) * 1f;
            //float projectileDirYPosition = transform.position.y + Mathf.Cos((startAngle * Mathf.PI) / 45) * 1f;
            //Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            //Vector3 projectileMoveDirection = (projectileVector - transform.position).normalized * 10; // bullet speed

            //GameObject bulletFired = Instantiate(bullet, transform.position, Quaternion.identity);
            //bulletFired.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.y);

            //startAngle += angleStep;
            //}
            yield return new WaitForSeconds(bulletDelay);
        }
    }
}
