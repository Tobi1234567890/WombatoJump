using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float MoveSpeed;

    private Rigidbody2D rb;
    private PlayerController target;
    private Vector2 moveDirection;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerController>();
        ShootInDirection();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void ShootInDirection()
    {
        moveDirection = (target.transform.position - transform.position).normalized * MoveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }
}
