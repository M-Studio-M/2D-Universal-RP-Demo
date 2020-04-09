using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    PlayerInput playerInput;
    PlayerMovement playerMovement;
    Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (playerInput.jumpAttack)
            animator.SetTrigger("jumpAttack");
        if (playerInput.attack)
            animator.SetTrigger("attack");

        animator.SetFloat("xVelocity", Mathf.Abs(playerInput.xVelocity));
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("isGround", playerMovement.isGround);
        animator.SetBool("isJump", playerInput.isJump);
        animator.SetBool("isHurt", playerInput.isHurt);
    }

}
