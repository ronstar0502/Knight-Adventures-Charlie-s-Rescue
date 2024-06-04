using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float horizontalInput, jumpInput;
    private bool onFloor;
    public int score;
    [SerializeField] private float health = 3;
    [SerializeField] private float moveSpeed, jumpForce;
    [SerializeField] private float damping = 0.25f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");
        FlipPlayerDirection();
        /*if(onFloor && horizontalInput != 0)
        {
            rb.velocity = new Vector2(horizontalInput*moveSpeed,rb.velocity.y);
        }*/
        if (jumpInput != 0 && onFloor)
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
        if (onFloor && horizontalInput == 0)
        {
            rb.velocity *= damping;
        }
        else if (onFloor)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }
    }
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        onFloor = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onFloor = false;
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
