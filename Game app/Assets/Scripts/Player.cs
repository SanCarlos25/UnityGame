using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Script
public class Player : MonoBehaviour
{
    public JoystickMovement movementJoystick;
    public float playerSpeed;
    public Animator animator;

    private Rigidbody2D rb;
    private string currentAnimaton;
    private float xAxis;
    private float yAxis;
    private float direction;


    // Animation player directions
    const float PLAYER_HORIZONTAL = 1;
    const float PLAYER_UP = 2;
    const float PLAYER_DOWN = 3;

    // Start is called before the first frame update
    void Start()
    {
        // fetch rb2D from the game object
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    // For input checks
    void Update()
    {
        xAxis = movementJoystick.joystickVector.x;
        yAxis = movementJoystick.joystickVector.y;

        animator.SetFloat("xMovement", Mathf.Abs(xAxis));
        animator.SetFloat("yMovement", Mathf.Abs(yAxis));
        animator.SetFloat("yDirectional", yAxis);
        animator.SetFloat("xDirectional", xAxis);
        
    }
    
    // Physics based time step loop
    // For executing physics and movement
    void FixedUpdate()
    {
        // transforming player model to correspond with direction of movement
        // right
        if(xAxis > 0)
        {
            transform.localScale = new Vector2(-20, 20);
        }
        // left
        else if(xAxis < 0)
        {
            transform.localScale = new Vector2(20, 20);
        }

        // MOVEMENT
        // move the player if the joystick is being moved
        if (movementJoystick.joystickVector.y != 0 || movementJoystick.joystickVector.x != 0)
        {
            rb.velocity = new Vector2(movementJoystick.joystickVector.x * playerSpeed, movementJoystick.joystickVector.y * playerSpeed);
            
            // ANIMATION
            // walking left/right
            if (Mathf.Abs(xAxis) > .7)
            {

                ChangeAnimationState("Woman1_WalkingSide");
                direction = PLAYER_HORIZONTAL;
            }
            // walking up
            if (yAxis > .7)
            {
                ChangeAnimationState("Woman1_WalkingBack");
                direction = PLAYER_UP;

            }
            // walking down
            if (yAxis < -.7)
            {
                ChangeAnimationState("Woman1_WalkingFront");
                direction = PLAYER_DOWN;
            }
        }
        // stop the player from moving if the joystick is not being moved
        else
        {
            rb.velocity = Vector2.zero;

            // ANIMATION
            // idle left/right
            if(direction == PLAYER_HORIZONTAL)
            {
                ChangeAnimationState("Woman1_IdleSide");
            }
            // idle facing back
            if(direction == PLAYER_UP)
            {
                ChangeAnimationState("Woman1_IdleBack");
            }
            // idle facing front
            if(direction == PLAYER_DOWN)
            {
                ChangeAnimationState("Woman1_IdleFront");
            }
        }
    }

    // Animation Manager Function
    void ChangeAnimationState(string newAnimation)
    {
        // checks if the new animation is the same as the current animation
        if (currentAnimaton == newAnimation) return;

        // otherwise it plays the new animation
        animator.Play(newAnimation);
        // and updates the current animation to the new animation
        currentAnimaton = newAnimation;
    }
}
