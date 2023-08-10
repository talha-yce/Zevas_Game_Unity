using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    private float airControl = 0.1f;
    bool canJump = true;

    private float speed = 5f;

    private bool facingRight = true;
    private Animator anim;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    private Oyun_Yonetim healt;

    [SerializeField]
    private float jumpForce = 300f;

    public Rigidbody2D rb { get; set; }

    bool dead = false;
    bool attack = false;

    void Start()
    {

        healt = GetComponent<Oyun_Yonetim>();
        GetComponent<Rigidbody2D>().freezeRotation = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        HandleInput();
        if (healt.can <= 0)
        {
            if (!dead)
            {
                anim.SetBool("Dead", true);
                anim.SetFloat("Speed", 0);
                dead = true;
            }

        }
        else
        {
            anim.SetBool("Dead", false);
            dead = false;
        }
    }


    void FixedUpdate()
    {
        if (!dead)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            anim.SetBool("Ground", grounded);

            float horizontal = Input.GetAxis("Horizontal");
            float currentSpeed = speed;


            if (!grounded)
            {
                rb.velocity = new Vector2(horizontal * currentSpeed * airControl, rb.velocity.y);
            }
            else
            {

                rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);
            }

            anim.SetFloat("vSpeed", rb.velocity.y);
            anim.SetFloat("Speed", Mathf.Abs(horizontal));

            if (horizontal > 0 && !facingRight && !dead && !attack)
            {
                Flip(horizontal);
            }
            else if (horizontal < 0 && facingRight && !dead && !attack)
            {
                Flip(horizontal);
            }
        }
    }

    private void HandleInput()
    {
        if (!dead)
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt) && !dead)
            {
                attack = true;
                anim.SetBool("Attack", true);
                anim.SetFloat("Speed", 0);
            }

            if (Input.GetKeyUp(KeyCode.LeftAlt))
            {
                attack = false;
                anim.SetBool("Attack", false);
            }


            if (grounded && Input.GetKeyDown(KeyCode.Space) && !dead && canJump)
            {
                anim.SetBool("Ground", false);
                rb.AddForce(new Vector2(0, jumpForce));
                canJump = false;
            }
        }


    }


    private void Flip(float horizontal)
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
