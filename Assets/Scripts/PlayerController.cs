using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    private float moveVelocity;
    public bool facingRight = true;
    public float jumpHeight;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private Rigidbody2D rb;
    private Animator animator;
    private bool doubleJumped;

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void Update()
    {

        moveVelocity = movementSpeed * Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (rb.velocity.x > 0 && !facingRight)
        {
            FlipPlayer();
        }
        else if (rb.velocity.x < 0 && facingRight)
        {
            FlipPlayer();
        }

        if (grounded)
        {
            doubleJumped = false;
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
        }
        if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
}
