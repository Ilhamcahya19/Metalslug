using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rB;
    //Movement
    [SerializeReference]
    private float speed;
    private float speedLow;
    private float moveInput;

    //Jump
    [SerializeReference]
    private float jumpForce;
    [SerializeReference]
    private float circleRadius;
    private bool isGrounded;
    public Transform feetPos;
    public LayerMask whatIsGround;

    //Waktu Lompat
    [SerializeReference]
    private float jumpTime;
    private float jumpTimeCounter;
    private bool isJumping;
    bool sedangLompat;
    //Animasi
    private Animator anim;

    float moveButton;
    void Start()
    {
        Time.timeScale = 1;
        sedangLompat = false;
        moveButton = 0;
        anim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        //Jump
        isGrounded = Physics2D.OverlapCircle(feetPos.position, circleRadius, whatIsGround);
        if (isGrounded)
        {
            speedLow = 1;
            anim.SetBool("isJump", false);
        }
        else
        {
            speedLow = 0.8f;
            anim.SetBool("isJump", true);
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rB.velocity = new Vector2(rB.velocity.x, jumpForce);
        }
        if (isJumping && Input.GetKey(KeyCode.Space))
        {
            if (jumpTimeCounter > 0)
            {
                rB.velocity = new Vector2(rB.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else if (jumpTimeCounter < 0)
                isJumping = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            isJumping = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal") ;
        if (moveInput > 0)
            transform.eulerAngles = Vector3.zero;
        else if (moveInput < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);

        if (moveInput == 0)
            anim.SetBool("isWalk", false);
        else
            anim.SetBool("isWalk", true);
        rB.velocity = new Vector2(moveInput * speed * speedLow, rB.velocity.y);
    }

    public void kiriDown()
    {
        moveButton = -1;
    }
    public void buttonUp()
    {
        moveButton = 0;
    }

    public void kananDown()
    {
        moveButton = 1;
    }

    public void jumpDown()
    {
        sedangLompat = true;
    }
    public void jumpUp()
    {
        sedangLompat = false;
    }

}
