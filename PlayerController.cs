using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public int speed = 5;
    private bool facingRight = true;
    private float horizontalMove;
    public Animator animator;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        
        horizontalMove = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
    }


    void Update()
    {
        
        if(horizontalMove < 0.0f && facingRight){

            FlipPlayer();
        }

        if(horizontalMove > 0.0f && !facingRight)
        {
            FlipPlayer();
        }
    }

    void FlipPlayer(){

        facingRight = !facingRight;
        Vector2 playerScale = gameObject.transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}
