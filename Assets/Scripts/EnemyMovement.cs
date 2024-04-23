using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    void Update()
    {
        Move();
    }
    void Move()
    {
        //work on this
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * moveSpeed * Time.deltaTime;
    }
}
