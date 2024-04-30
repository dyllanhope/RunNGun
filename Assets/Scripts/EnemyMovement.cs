using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] int touchDamage = 5;
    [SerializeField] float touchDamageTime = 1;
    SpinyMovement player;
    bool isTouchingPlayer = false;
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
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.GetPlayerPos(), moveSpeed * Time.deltaTime);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(CheckTouchingPlayer(collision));
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTouchingPlayer = false;
        }
    }
    IEnumerator CheckTouchingPlayer(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var playerHealthManager = collision.gameObject.GetComponent<HealthManager>();
            isTouchingPlayer = true;
            do
            {
                playerHealthManager.TakeDamage(touchDamage);
                yield return new WaitForSeconds(touchDamageTime);

            } while (isTouchingPlayer == true);
        }

        yield return null;
    }
}
