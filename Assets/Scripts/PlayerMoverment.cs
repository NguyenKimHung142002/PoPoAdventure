using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverment : MonoBehaviour
{   
    // get character 
    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D boxColli;
    private SpriteRenderer spriteRenderer;
    private float dirX = 0f;

    //check ground for jumping
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private AudioSource jumbSoundEffect; 
    //state of movement
    private enum MovementState { idle, running, jumping, falling}

    // Start is called before the first frame update
    private void Start()
    {   
        // 
        rb = GetComponent<Rigidbody2D>();
        boxColli = GetComponent<BoxCollider2D>();

        // get animator to change animation of character
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {   
        // using raw to stop imediately after release button
        // dirX to check whether horizontal key down or not
        // -1 if a (left) and 1 if d (right)
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded()) 
        {
            jumbSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimatorState();
    }

    //transition movement sprites
    private void UpdateAnimatorState() {

        MovementState state;

        //check if character are moving
        if(dirX > 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false; 
        } 
        else if(dirX < 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true; 
        } 
        else 
        {
            state = MovementState.idle;
        }

        if ( rb.velocity.y > .1f ) 
        {
            state = MovementState.jumping;
        } 
        else if ( rb.velocity.y < -1f ) {
            state = MovementState.falling;
        } 

        animator.SetInteger("state", ((int)state));
    }

    //check whethere character touch ground or not
    private bool IsGrounded() {
        return Physics2D.BoxCast(boxColli.bounds.center, boxColli.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


}
