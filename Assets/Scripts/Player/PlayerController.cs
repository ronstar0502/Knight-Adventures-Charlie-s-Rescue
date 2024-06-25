using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed, jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private MovingPlatform currentPlatform;
    private float horizontalInput;
    private bool onFloor;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        /*horizontalInput = Input.GetAxis("Horizontal");
        if(onFloor && horizontalInput != 0)
        {
            rb.velocity = new Vector2(horizontalInput*moveSpeed,rb.velocity.y);
        }
        if (jumpInput != 0 && onFloor)
        {
            Jump();
        }*/

        FlipPlayerDirection();
        if (Input.GetKeyDown(KeyCode.Space) && onFloor)
        {
            Jump();
        }
    }


    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        onFloor = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
            animator.SetBool("isRunning", true);
        }
        else animator.SetBool("isRunning", false);
    }

    private void Jump()
    {       
        rb.velocity = Vector2.up * jumpForce;
    }

    private void FlipPlayerDirection()
    {
        if (horizontalInput == 1)
        {
            sr.flipX = false;
        }
        else if (horizontalInput == -1)
        {
            sr.flipX = true;
        }
    }
}
