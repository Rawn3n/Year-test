using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float orgSpeed = 5;
    float speed;

    public float jumpVelocity = 5f;
    public int maxJumps = 2;
    int jumpsLeft;
    public Transform groundcheck;
    public float groundRadiousCheck = 0.5f;
    public LayerMask groundMask;
    bool isJumping = false;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float maxJumpTimer = 0.15f;
    float jumpTimer;
    float basegravityScale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = maxJumps;
        basegravityScale = rb.gravityScale;
        jumpTimer = maxJumpTimer;
        speed = orgSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move;
        move.x = Input.GetAxisRaw("Horizontal") * speed;
        move.y = rb.linearVelocity.y;
        rb.linearVelocity = move;

        if (Physics2D.OverlapCircle(groundcheck.position, groundRadiousCheck, groundMask))
        {
            jumpsLeft = maxJumps;
            isJumping = false;
        }

        if (Input.GetButton("Jump") && jumpsLeft > 0 && jumpTimer > 0)
        {
            isJumping = true;
            rb.gravityScale = basegravityScale;
            jumpTimer -= Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump") && jumpsLeft > 0)
        {
            jumpsLeft -= 1;
            jumpTimer = maxJumpTimer;
        }
    }

    public void Boost(int speedMod)
    {
        speed *= speedMod;
        Invoke("ResetSpeed", 5f);
    }

    void ResetSpeed()
    {
        speed = orgSpeed;
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            //rb.AddForce(Vector2.up * jumpVelocity); //jumpVelocity = 40
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpVelocity);
            isJumping = false;
        }

        if (rb.linearVelocity.y < 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = fallMultiplier * basegravityScale;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = lowJumpMultiplier * basegravityScale;
        }
        else
        {
            rb.gravityScale = basegravityScale;
        }
    }

    public bool canAttack()
    {
        return Physics2D.OverlapCircle(groundcheck.position, groundRadiousCheck, groundMask);
    }

}
