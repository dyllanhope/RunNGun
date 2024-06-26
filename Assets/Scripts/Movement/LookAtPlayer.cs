using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    SpinyMovement player;
    private void Awake()
    {
        player = FindObjectOfType<SpinyMovement>();
    }

    void Update()
    {
        Look();
    }

    void Look()
    {

        if (player != null)
        {
            Vector3 direction = player.GetPlayerPos() - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
