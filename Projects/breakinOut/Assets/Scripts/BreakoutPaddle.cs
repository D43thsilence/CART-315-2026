using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutPaddle : MonoBehaviour
{
    private float xPos;
    private float yPos;
    public float paddleSpeed = .05f;
    public float leftWall, rightWall;

    public KeyCode leftKey, rightKey, jumpKey;

    public LayerMask whatIsGround;

    //gravity variables
    float gravity = -9.8f;
    float groundGravity = -0.05f;

    // Jumping Variables
    public float jumpForce;
    bool isJumping = false;
    bool grounded = true;
    public float playerHeight;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {

    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics.Raycast(transform.position, Vector2.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        if (Input.GetKey(leftKey))
        {
            if (xPos > leftWall)
            {
                xPos -= paddleSpeed;
            }
        }

        if (Input.GetKey(rightKey))
        {
            if (xPos < rightWall)
            {
                xPos += paddleSpeed;
            }
        }

        if (grounded = true && Input.GetKey(jumpKey))
        {
            if (xPos < rightWall)
            {
                Jump();
            }
        }
        transform.localPosition = new Vector3(xPos, transform.position.y, 0);
        Debug.Log(grounded);
    }

    private void Jump()
    {
        // reset y velocity
        //Always jumping at exact same height
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        //only applying the force once.
        rb.AddForce(transform.right * jumpForce, ForceMode2D.Impulse);
        grounded = false;
        isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}

