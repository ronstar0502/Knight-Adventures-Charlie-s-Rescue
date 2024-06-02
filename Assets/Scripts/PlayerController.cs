using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalInput, jumpInput;
    private bool onFloor;
    private int coins;
    [SerializeField] private float health = 3;
    [SerializeField] private float moveSpeed, jumpForce;
    [SerializeField] private float damping = 0.25f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");

        rb.velocity = new Vector2 (horizontalInput*moveSpeed,rb.velocity.y);
        if(jumpInput != 0 && onFloor)
        {
            rb.AddForce(Vector2.up*jumpForce);
        }
    }

    private void FixedUpdate()
    {
        if(onFloor && horizontalInput == 0)
        {
            rb.velocity*=damping;
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
            coins += coin.GetValue();
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
        SceneManager.LoadScene("Menu");
    }
}
