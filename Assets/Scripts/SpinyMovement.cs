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
    bool isFiring = false;
    Coroutine firingCoroutine;

    void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
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
        float facingAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

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

    IEnumerator FireBullets()
    {
        while (true)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(bulletDelay);
        }
    }
}
