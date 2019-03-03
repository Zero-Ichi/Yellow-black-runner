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

    protected SpriteRenderer spriteRenderer;
    protected Animator animator;

    protected bool isHurt = false;
    protected bool isDead = false;

    protected override void Awake()
    {
        base.Awake();
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

    public void SlowDown(float speedDivider, float slowdownTime)
    {
        if (isHurt)
        {
            this.Dead();
        }
        else
        {
            float MaxSpeedOrigin = maxSpeed;
            maxSpeed /= speedDivider;
            this.Hurt();
            //Lance une fonction coroutine
            StartCoroutine(RecoverySpeed(slowdownTime, MaxSpeedOrigin));
            Debug.Log("Aïe !! je vais a : " + maxSpeed + " au lieux de " + MaxSpeedOrigin);
        }
    }

    public void Jump(float jumpValue)
    {
        if (!this.isDead)
        {
            velocity.y = jumpValue;
            isGrounded = true;
        }
    }

    public void Dead()
    {
        this.isDead = !this.isDead;
        animator.SetBool("IsDead", this.isDead);
        GameManager.StopGame();

    }

    private void Hurt()
    {
        isHurt = !isHurt;
        animator.SetBool("Hurt", isHurt);
    }

    IEnumerator RecoverySpeed(float slowdownTime, float MaxSpeedOrigin)
    {
        //Attends le nombre de seconde passer en paramètre 
        yield return new WaitForSeconds(slowdownTime);
        maxSpeed = MaxSpeedOrigin;
        this.Hurt();
        Debug.Log("Speed " + maxSpeed);
    }
    
}
