using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // "public" variables
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 200.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatisGround;

     private float movement;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        isGrounded = GroundCheck();

        if (isGrounded && Input.GetAxisRaw("Jump") > 0)
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Trap")
        {
            Destroy(this.gameObject);
        }
    }
}
