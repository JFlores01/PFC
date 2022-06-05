using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public int speed = 5;
    private bool facingRight = true;
    private float horizontalMove;
    public Animator animator;

    public int jumpPower = 200;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool isJumping;


    public static bool death;
    public static bool growUp;
    private float countdown = 0.5f;

    

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        death = false;
        growUp = false;
    }

    void FixedUpdate() {
        
        horizontalMove = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
    }


    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        animator.SetBool("IsGrounded", isGrounded);

        if(horizontalMove < 0.0f && facingRight){

            FlipPlayer();
        }

        if(horizontalMove > 0.0f && !facingRight)
        {
            FlipPlayer();
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            Jump();
        }

        if(death)
        {
            animator.SetTrigger("Death");
            countdown -= Time.deltaTime;
            if(countdown > 0f)
            {
                Invoke("Death", 0.5f);
            }

            if(transform.position.y < -30)
            SceneManager.LoadScene("Super Mario");
        }
        

        if(growUp)
        {
            animator.SetBool("GrowUp", growUp);
        }

        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("question"))
        {

            isJumping = false;
            rb.velocity = Vector2.down * 5;

        }

    }

    void FlipPlayer()
    {

        facingRight = !facingRight;
        Vector2 playerScale = gameObject.transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpPower);
    }

    void Death()
    {

        GetComponent<Collider2D>().isTrigger = true;
        rb.velocity = new Vector2(rb.velocity.x, 5f);
        
    }
}
