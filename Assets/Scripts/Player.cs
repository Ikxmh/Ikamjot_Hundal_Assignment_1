using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    private float yLevel = 0;
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

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Move()
    {
        movement = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * speed;
        transform.Translate(movement, 0, 0);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground") 
        {
            isGrounded = true;
        }

        else if (other.gameObject.tag == "Trap")
        {
            Destroy(this.gameObject);
        }
    }
}
