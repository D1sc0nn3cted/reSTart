using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playermovement : MonoBehaviour
{
    public float movementspeed = 5f;
    public float scale = 8f;
    public float jumpforce = 8f;
    public float dashforce = 12f;
    public float dashcools = 0.2f;

    public Transform groundcheck;
    public float groundcheckradius = 0.2f;
    public float fallgravity = 3f;
    public float jumpgravity = 2f;
    public Transform lcheck;
    public Transform rcheck;
    public float dashDuration = 0.15f;

    public float sidecheckradius = 0.2f;
    public LayerMask groundlayer;

    private Rigidbody2D rb;
    private Animator animator;
    private float moveinput;
    private bool isgrounded;
    private float dashTime;
    private bool isright;
    private bool isleft;
    private bool isDashing = false;
    private bool canDash = true;





    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        GetInput();
        updateanimation();
        FlipSprite();
        HandleJump();
        HandleDash();
        if (isDashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0f)
            {
                isDashing = false;
            }
        }
    }
    private void FixedUpdate()
    {
        Move();
        CheckGround();
        Sidecheck();
        Gravityupd();
        
    }

    void GetInput()
    {
        moveinput = 0f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed && isleft)
            moveinput = -1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed && isright)
            moveinput = 1f;
        
    }
    void Move(){
        if (!isDashing)
            rb.linearVelocity = new Vector2(moveinput * movementspeed, rb.linearVelocityY);
    }
    void FlipSprite()
    {
        if (moveinput < 0)
            transform.localScale = new Vector3(scale, scale, scale);
        else if (moveinput > 0)
            transform.localScale = new Vector3(scale * -1, scale, scale);
        
    }
    void HandleJump()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isgrounded)
        {
            Jump();
        }
    }
    void Jump()
    {
        rb.linearVelocityY = jumpforce;
    }
    void CheckGround()
    {
        isgrounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckradius, groundlayer);
    }
    void updateanimation()
    {
        if (!isgrounded)
        {
            if (rb.linearVelocityY > 0)
                animator.Play("Jump");
            else
                animator.Play("Fall");
        }
        else if (moveinput != 0)
            animator.Play("Run");
        else
            animator.Play("Idle");

    }
    void Sidecheck()
    {
        isright = Physics2D.OverlapCircle(rcheck.position, sidecheckradius, groundlayer);
        isleft = Physics2D.OverlapCircle(lcheck.position, sidecheckradius, groundlayer);
    }
    void Gravityupd() {
        if (rb.linearVelocityY > 0)
            rb.gravityScale = jumpgravity;
        else
            rb.gravityScale = fallgravity;
    }
    
    void Dash()
    {
        rb.linearVelocityX = rb.linearVelocityX + moveinput * dashforce;
        Debug.Log("Dash");
        isDashing = true;

    }
    void HandleDash()
    {
        if (moveinput != 0 && Keyboard.current.shiftKey.wasPressedThisFrame && canDash)
        {
            Dash();
            canDash = false;
            dashTime = dashDuration;
            Invoke("ResetDash", dashcools);
            Debug.Log("hDash");
        }
            

    }
    void ResetDash()
    {
        canDash = true;
        Debug.Log("RDash");
    }
}
