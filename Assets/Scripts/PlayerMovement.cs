using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerAnimation playerAnimation;

    Rigidbody2D rb;
    Collider2D coll;

    public LayerMask groudLayer;
    public float speed;
    public float jumpForce;

    public bool isGround;
    int direction = 1;  //Player direction

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimation = GetComponent<PlayerAnimation>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }
    private void Update()
    {
        isGround = coll.IsTouchingLayers(groudLayer);
    }
    private void FixedUpdate()
    {
        GroundMovement();
        AirControl();

    }

    void GroundMovement()
    {
        rb.velocity = new Vector2(playerInput.xVelocity * speed * Time.fixedDeltaTime, rb.velocity.y);

        if (playerInput.xVelocity * direction < 0)
        {
            FlipDirection();
        }
    }

    void AirControl()
    {
        if (playerInput.isJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);
            // rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            playerInput.isJump = false;
        }
    }

    void FlipDirection()
    {
        direction *= -1;

        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }
}
