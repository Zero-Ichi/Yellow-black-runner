using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    [SerializeField]
    protected float maxSpeed = 5;
    [SerializeField]
    protected float jumpTakeOffSpeed = 5;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
  
    private bool isDead = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    

    protected override void ComputeVelocity()
    {
        if (isDead)
            return;

        Vector2 move = Vector2.zero;

        move.x = Vector2.right.x;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump(jumpTakeOffSpeed);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            
            //if (velocity.y > 0)
            //{
            //    velocity.y = velocity.y * .5f;
            //}
        }
        bool flipSprite = (spriteRenderer.flipX ? move.x > 0.01f : move.x < -0.01f);
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("Grounded", isGrounded);
        animator.SetFloat("VelocityY", velocity.y);

        TargetVelocity = move * maxSpeed;

    }

    public void Jump(float jumpValue)
    {
        if (!this.isDead)
        {
            velocity.y = jumpValue;
            isGrounded = true;
        }
    }

    public void Dead(bool isDead)
    {
        this.isDead = isDead;
        animator.SetBool("IsDead", isDead);

    }
}
