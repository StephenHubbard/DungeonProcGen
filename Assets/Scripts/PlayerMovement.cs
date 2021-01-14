using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    private Vector2 moveDirection;

    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("IdleSide", true);
            animator.SetBool("IdleBack", false);
            animator.SetBool("IdleFront", false);

        }
        else if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("IdleSide", true);
            animator.SetBool("IdleBack", false);
            animator.SetBool("IdleFront", false);
        }

        if (moveDirection.y > 0)
        {
            animator.SetBool("IdleSide", false);
            animator.SetBool("IdleBack", true);
            animator.SetBool("IdleFront", false);
        }
        else if (moveDirection.y < 0)
        {
            animator.SetBool("IdleSide", false);
            animator.SetBool("IdleBack", false);
            animator.SetBool("IdleFront", true);
        }

    }
}
