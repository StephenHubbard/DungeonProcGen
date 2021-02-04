using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer spriteRenderer;

    private Vector2 moveDirection;

    void Update()
    {
        ProcessInputs();
        Move();
    }

    private void FixedUpdate()
    {
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized * Time.deltaTime;
    }


    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        // Can use this template for player animations

        //if (moveDirection.x < 0)
        //{
        //}
        //else if (moveDirection.x > 0)
        //{
        //}
        //else if (moveDirection.y > 0)
        //{
        //}
        //else if (moveDirection.y < 0)
        //{
        //}

    }
}
