using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Animator animator;
    private Rigidbody2D rb2d;
   
    public float stepTime = 0.5f;
    float timer;
    public float horizontalMov;
    public float verticalMov;
    public float speed;
    public float jumpforce;
    public bool isJumping = false;
    bool facingRight = true;

    bool wallJump;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;

    //private bool m_FacingRight = true;  
    [SerializeField]
    private bool isTouchingFront;
    public Transform frontCheck;
    [SerializeField]
    private bool wallSliding;
    [SerializeField]
    private float wallSlidingSpeed;
    [SerializeField] private LayerMask whatIsClimbable;



    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;

    private bool isGrounded = false;

    [SerializeField] private bool isDoubleJumpingEnabled;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMov = Input.GetAxisRaw("Horizontal") * speed;
        verticalMov = Input.GetAxisRaw("Vertical") * speed;

        //animator.SetFloat("Speed", Mathf.Abs(horizontalMov));


        if (horizontalMov != 0)
        {
            timer += Time.deltaTime;
            if (timer > stepTime)
            {
                
                timer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded && !wallSliding)
            {
                Debug.Log("isJumping");

                rb2d.AddForce(new Vector2(0.0f, jumpforce * speed));
                isGrounded = false;
                isDoubleJumpingEnabled = true;
            }

            else if (isDoubleJumpingEnabled && !wallSliding)
            {
                rb2d.AddForce(new Vector2(0.0f, jumpforce * speed));
                isGrounded = false;
                isDoubleJumpingEnabled = false;

            }


            if (wallSliding)
            {
                wallJump = true;
                Debug.Log("wall jump " + wallJump);
                Invoke("setWallJumpToFalse", wallJumpTime);
            }
        }


        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, groundCheckRadius, whatIsClimbable);

        if(isTouchingFront == true && isGrounded == false && horizontalMov != 0)
        {
            wallSliding = true;
            //animator.SetBool("Jump", false);
            //animator.SetBool("Grab", true);
        }
        else
        {
            //animator.SetBool("Grab", false);
            wallSliding = false;
        }

        if(wallSliding)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Clamp(rb2d.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

    }

    void FixedUpdate()
    {
        if (horizontalMov > 0 && !facingRight)
        {
            Flip();
        }
        if (horizontalMov < 0 && facingRight)
        {
            Flip();
        }

        if (horizontalMov > 0.1f || horizontalMov < -0.1f)
        {
            rb2d.AddForce(new Vector2(horizontalMov * speed, 0f), ForceMode2D.Impulse);
        }


        if (wallJump == true)
        {
            Debug.Log("wall jump is true!" + wallJump);

            rb2d.AddForce(new Vector2(xWallForce * -horizontalMov, yWallForce));
        }

        isGrounded = GroundCheck();

        rb2d.velocity = new Vector2(horizontalMov, rb2d.velocity.y);

    }

    void setWallJumpToFalse()
    {
        wallJump = false;
       // animator.SetBool("Grab", false);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround) && !wallSliding;
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "ClimbableWalls")
        {
            isJumping = false;
            //animator.SetBool("Jump", false);
        }

        

        else if(collision.gameObject.tag == "Spike" || collision.gameObject.tag == "Bullet")
        {
            FindObjectOfType<GameOverScreen>().GameOver();

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "ClimbableWalls")
        {
            isJumping = true;
            //animator.SetBool("Jump", true);
            

        }

        
 
    }   

}
