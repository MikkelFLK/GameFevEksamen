using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
    [SerializeField] private float jumpLenght = 10f;
    [SerializeField] private float jumpHeight = 15f;
    [SerializeField] private LayerMask ground;
    //[SerializeField] private AIState aiState = AIState.idel;

    //private enum AIState { idel, jumping, falling, death }
    private bool facingLeft = true;
    private Rigidbody2D rb;
    private Collider2D coll;

    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Transition from Jump to Fall
        if (anima.GetBool("Jumping"))
        {
            if (rb.velocity.y < .1f)
            {
                anima.SetBool("Falling", true);
                anima.SetBool("Jumping", false);
            }
        }
        //Transition from Fall to Idel
        if (coll.IsTouchingLayers(ground) && anima.GetBool("Falling"))
        {
            anima.SetBool("Falling", false);
        }
    }

    private void Move()
    {
        if (facingLeft)
        {
            //Test to see if we are beyond leftcap
            if (transform.position.x > leftCap)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-jumpLenght, jumpHeight);
                    anima.SetBool("Jumping", true);
                }
            }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightCap)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(jumpLenght, jumpHeight);
                    anima.SetBool("Jumping", true);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
    }
}