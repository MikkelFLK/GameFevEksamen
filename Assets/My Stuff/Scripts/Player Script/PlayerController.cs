using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    [SerializeField] private TextMeshProUGUI scoretext;

    private float movment;
    private Rigidbody2D rb;
    private Animator anima;
    private int score = 0;
    
    private enum State { idle, running, jumping, falling};
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

        Move();
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
}
