using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoretext;
    [SerializeField] private float hurtVelocity = 10f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private float movment;
    private Rigidbody2D rb;
    private Animator anima;
    private int score = 0;
    
    private enum State { idle, running, jumping, falling, hurt};
    private State state = State.idle;


    //Grund check 
    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();  
    }

    private void FixedUpdate()
    {
        if (state != State.hurt)
        {
            Move();
        }
        StateManager();
        anima.SetInteger("State", (int)state); 
          
    }

    private void StateManager()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (isGrounded == true)
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            if (Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }

    private void Move()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        movment = Input.GetAxisRaw("Horizontal");

        if (movment < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movment > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        rb.velocity = new Vector2(movment * moveSpeed, rb.velocity.y);

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            state = State.jumping;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            score += 10;
            scoretext.text = "Score: " + score;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (state == State.falling)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                if(collision.gameObject.transform.position.x > transform.position.x)
                {
                    state = State.hurt;
                    //Enemy to my right, therefore I should be hurt and move left
                    rb.velocity = new Vector2(-hurtVelocity, rb.velocity.y);
                }
                else
                {
                    state = State.hurt;
                    //Enemy to my left, therefore I should be hurt and move right
                    rb.velocity = new Vector2(hurtVelocity, rb.velocity.y);
                }
            }
            
        }
    }
}
