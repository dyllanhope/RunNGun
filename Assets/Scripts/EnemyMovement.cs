using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    SpinyMovement player;
    void Awake()
    {
        player = FindObjectOfType<SpinyMovement>();
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.GetPlayerPos(), moveSpeed * Time.deltaTime);
    }
}
