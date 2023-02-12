using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private Rigidbody2D playerrbd2;
    public float playerSpeed;
    public float jumpForce;
    private float jumpCount;
    public float maxJump;
    float horizontalInput;
    private Animator anim;
    private bool isWalled;
    private float originalGrav;
    public float dashForce;
    private bool isDashing;
    private bool canDash = true;
    public float dashCooldown;
    public float dashingTime;
    private float dashdirection;
    [SerializeField] TrailRenderer tr;
    private bool staticDirection;
    void Start()
    {
        playerrbd2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        originalGrav = playerrbd2.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        playerrbd2.velocity = new Vector2(horizontalInput * playerSpeed, playerrbd2.velocity.y);
        Jump();
        PlayerDirection();
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
       
        dashDirection();
       
    }
    
    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && jumpCount < maxJump && !isWalled)
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJump && !isWalled)
        {
            playerrbd2.velocity = new Vector2(playerrbd2.velocity.x, jumpForce);
            jumpCount++;           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
                  
            playerrbd2.gravityScale = originalGrav;
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("-Wallturn") || collision.gameObject.CompareTag("Wallturn"))
        {
            isWalled = true;
            playerrbd2.gravityScale = 0;
            
        }
        if (collision.gameObject.CompareTag("-Wallturn"))
        {
            transform.localScale = new Vector3(1, 1, 1);
         
        }
        if (collision.gameObject.CompareTag("Wallturn"))
        {
            transform.localScale = new Vector3(-1, 1, 1);         
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("-Wallturn"))
        {
            isWalled = false;
            playerrbd2.gravityScale = originalGrav;            
        }
    }
    void PlayerDirection()
    {
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1, 1);
            staticDirection = true;
        }
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            staticDirection = false;
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        playerrbd2.gravityScale = 0f;
        playerrbd2.velocity = new Vector2(dashForce * dashdirection, 0f);
        tr.emitting = true;  
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        playerrbd2.gravityScale = originalGrav;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
             
    }
        private void  dashDirection()
    {
        if (staticDirection )
        {


            dashdirection = 1f;
        }
        else if (!staticDirection)
        {
            dashdirection = -1f;
        }
        ;
    }
    }


