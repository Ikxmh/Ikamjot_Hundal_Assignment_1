using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // "public" variables

    // jumping-related variables 
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 200.0f;
    private float fallIncrease = 2.5f;

    // detecting the ground variables 
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatisGround;

    private float movement;

    // component calling variables 
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        isGrounded = GroundCheck();

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallIncrease - 1) * Time.deltaTime;
        }
        else if (isGrounded && Input.GetAxisRaw("Jump") > 0)
        {
            Jump();
        }
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

    private void Move()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }


    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatisGround);
    }

}
