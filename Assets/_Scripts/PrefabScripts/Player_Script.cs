using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class Player_Script : MonoBehaviour
{
    
    public AudioClip Player_Hit;

    public float speed;    // Here we set a float variable to hold our speed value
    private Rigidbody2D rb;  // This is to hold the rigidbody component
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public bool flipSprite;

    private Vector2 touchOrigin = -Vector2.one;
    // Start is called as you start the game, we use it to initially give values to things
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = Player_Hit;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();  // Here we actually reference the rigidbody.
    }

    public void mobileWalk()
    {
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            if (myTouch.phase == TouchPhase.Began)
            {
                //If so, set touchOrigin to the position of that touch
                touchOrigin = myTouch.position;
            }
        }
    }
    void FixedUpdate()
    { 
        // Getting a current velocity from object(Player)
        Vector2 curVel = rb.velocity;
        // Getting the Input horizontally and puts it to the rigid body velocity
        curVel.x = Input.GetAxisRaw("Horizontal") * speed; // max speed = 5
        //Mobile
        curVel.x = CrossPlatformInputManager.GetAxisRaw("Horizontal") * speed;
        // sets the curVel to the rigidbody
        rb.velocity = curVel;
        // Whether pressing left or right, setting the isWalking on animator
        if (curVel.x > 0 || curVel.x < 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        // Set IsFired true in Chain script when clicking space
        if (Input.GetKeyDown("space"))
        {
            animator.SetTrigger("PlayerShot");

            Fire();
        }
        // Flipping sprite on whether the velocity is x + or x -
        flipSprite = (spriteRenderer.flipX ? (curVel.x > 0.0f) : (curVel.x < 0.0f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        
    }

    public void clickFireMobile()
    {
        animator.SetTrigger("PlayerShot");
        Fire();
    }

   
    void Fire()
    {  
            Chain.IsFired = true;
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {   
        //Check collision name
        if (col.gameObject.tag == "Ball")
        {
            GetComponent<AudioSource>().Play();
            Destroy(gameObject);

        }
        
        
    }

       

}