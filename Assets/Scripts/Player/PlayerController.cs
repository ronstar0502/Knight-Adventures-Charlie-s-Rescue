using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float accelerationTime = 0.1f;
    [SerializeField] private float decelerationTime = 0.1f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private float horizontalInput;
    private bool onFloor;
    private float velocitySmoothing;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        onFloor = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        FlipPlayerDirection();

        if (Input.GetKeyDown(KeyCode.Space) && onFloor)
        {
            Jump();
        }

        ApplyFallMultiplier();
    } 

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float movementSpeed = horizontalInput * moveSpeed;
        float smoothedMovementSpeed = Mathf.SmoothDamp(rb.velocity.x, movementSpeed, ref velocitySmoothing, horizontalInput != 0 ? accelerationTime : decelerationTime);
        //ref velocitySmoothing ->  velocitySmoothing is used by Mathf.SmoothDamp to keep track of the velocity change over time
        //horizontalInput != 0 ? accelerationTime : decelerationTime -> a way to put a value with a statement
        rb.velocity = new Vector2(smoothedMovementSpeed, rb.velocity.y);

        animator.SetBool("isRunning", horizontalInput != 0); // another way to set the bool
    }

    private void ApplyFallMultiplier()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void FlipPlayerDirection()
    {
        if (horizontalInput > 0)
        {
            sr.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            sr.flipX = true;
        }
    }
}
