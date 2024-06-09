using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private float horizontalInput;
    private bool onFloor;
    public int score;
    [SerializeField] private float health = 3;
    [SerializeField] private float moveSpeed, jumpForce;
    //[SerializeField] private float damping = 0.25f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;

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

        /*if (onFloor && horizontalInput == 0)
        {
            rb.velocity *= damping;
        }
        else if (onFloor)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }*/
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Coin coin = other.gameObject.GetComponent<Coin>();
            score += coin.GetValue();
            Destroy(coin.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        if (health - damage <= 0)
        {
            health = 0;
            RestartLevel();
        }
        else
        {
            health-=damage;
        }
        
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene("Level_1");
    }
}
