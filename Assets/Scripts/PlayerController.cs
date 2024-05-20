using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizantalInput, jumpInput;
    private bool onGround;
    [SerializeField] private float moveSpeed, jumpForce;
    [SerializeField] private float damping = 0.25f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        horizantalInput = Input.GetAxis("Horizantal");
        jumpInput = Input.GetAxis("Jump");
    }
}
