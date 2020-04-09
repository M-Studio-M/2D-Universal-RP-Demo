using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float xVelocity;

    public bool jumpAttack;
    public bool attack;

    public bool isJump;
    public bool isHurt;
    public float lastAttack;

    void Update()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
            isHurt = !isHurt;
        CheckAttack();
    }

    void CheckAttack()
    {
        if (Time.time - lastAttack >= 1)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                jumpAttack = true;
                lastAttack = Time.time;
            }

        }
        else
            jumpAttack = false;

        if (Time.time - lastAttack >= 0.5f)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                attack = true;
                lastAttack = Time.time;
            }

        }
        else
            attack = false;

    }
}
