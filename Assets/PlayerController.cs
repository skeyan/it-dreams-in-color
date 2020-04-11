using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sr;
    Transform tr;

    public float velocity;
    public float jumpForce;
    bool isGrounded;
    public bool isMoving;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    Animator anim;

    public string currentFlyColor;
    public List<GameObject> myFlies; // currently, game only allows for one fly follower

    public bool shouldTakeInput;

    AudioSource a;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        tr = gameObject.GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
        isMoving = false;
        shouldTakeInput = true;
        a = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldTakeInput)
        {
            //Plays the jump animation based on the "Grounded" boolean
            anim.SetBool("Grounded", isGrounded);
            anim.SetFloat("VelocityY", rb.velocity.y);
            anim.SetBool("Walking", isMoving);

            // Prevent double jump by checking if player is grounded
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

            // Player Movement - Horizontal
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                isMoving = true;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    rb.velocity = new Vector2(-1.3f * velocity, rb.velocity.y);

                }
                else
                {
                    rb.velocity = new Vector2(-velocity, rb.velocity.y);
                }
                if (tr.localScale.x > 0)
                    tr.localScale = new Vector3(-1 * tr.localScale.x, tr.localScale.y, tr.localScale.z);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                isMoving = true;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    rb.velocity = new Vector2(1.3f * velocity, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(velocity, rb.velocity.y);
                }
                if (tr.localScale.x < 0)
                    tr.localScale = new Vector3(-1 * tr.localScale.x, tr.localScale.y, tr.localScale.z);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                isMoving = false;
            }

            // Jumping (with no double jump)
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            // Footstep sounds
            if(isMoving && isGrounded)
            {
                if(!a.isPlaying)
                {
                    a.Play();
                }
            }
            else
            {
                a.Stop();
            }
        }

       
    }

}
