using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    
    protected float maxSpeed = 0;
    [SerializeField]
    protected float jumpTakeOffSpeed = 5;

    protected SpriteRenderer spriteRenderer;
    protected Animator animator;

    public bool IsHurt { get; set; }
    public bool IsDead { get; set; }

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }


    protected override void ComputeVelocity()
    {
        if (IsDead)
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
        if (!this.IsDead)
        {
            velocity.y = jumpValue;
            isGrounded = true;
        }
    }

    public void Dead()
    {
        this.IsDead = !this.IsDead;
        animator.SetBool("IsDead", this.IsDead);
        GameManager.StopGame();

    }

    public void Hurt()
    {
        IsHurt = !IsHurt;
        animator.SetBool("Hurt", IsHurt);
    }

    
}
