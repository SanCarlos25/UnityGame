using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Script
public class Player : MonoBehaviour
{
    public JoystickMovement movementJoystick;
    public float playerSpeed;
    public Animator animator;
    public static int Selected_character;

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
        //fetch animator component
        animator = GetComponent<Animator>();

        // Gets selected character from SkinManager
    
        Selected_character = SkinManager.character_choice;
        //Debug.Log("Selected_character = " + Selected_character);
        
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

    void CharacterMovement(string WalkingSide, string WalkingUp, string WalkingDown, string IdleSide, string IdleBack, string IdleFront)
    {
        // MOVEMENT
            // move the player if the joystick is being moved
            if (movementJoystick.joystickVector.y != 0 || movementJoystick.joystickVector.x != 0)
            {
                rb.velocity = new Vector2(movementJoystick.joystickVector.x * playerSpeed, movementJoystick.joystickVector.y * playerSpeed);
                
                // ANIMATION
                // walking left/right
                if (Mathf.Abs(xAxis) > .7)
                {

                    ChangeAnimationState(WalkingSide);
                    direction = PLAYER_HORIZONTAL;
                }
                // walking up
                if (yAxis > .7)
                {
                    ChangeAnimationState(WalkingUp);
                    direction = PLAYER_UP;

                }
                // walking down
                if (yAxis < -.7)
                {
                    ChangeAnimationState(WalkingDown);
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
                    ChangeAnimationState(IdleSide);

                }
                // idle facing back
                if(direction == PLAYER_UP)
                {
                    ChangeAnimationState(IdleBack);
                }
                // idle facing front
                if(direction == PLAYER_DOWN)
                {
                    ChangeAnimationState(IdleFront);
                }
            }
    }
    
    // Physics based time step loop
    // For executing physics and movement
    void FixedUpdate()
    {
        // transforming player model to correspond with direction of movement
        // right
        if(xAxis > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        // left
        else if(xAxis < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }


        if(Selected_character == 0)
        {
            CharacterMovement("Woman1_WalkingSide","Woman1_WalkingBack","Woman1_WalkingFront","Woman1_IdleSide","Woman1_IdleBack","Woman1_IdleFront");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if(Selected_character == 1) 
        {
            // MOVEMENT
            // move the player if the joystick is being moved
            if (movementJoystick.joystickVector.y != 0 || movementJoystick.joystickVector.x != 0)
            {
                rb.velocity = new Vector2(movementJoystick.joystickVector.x * playerSpeed, movementJoystick.joystickVector.y * playerSpeed);
                
                // ANIMATION
                // walking left/right
                if (Mathf.Abs(xAxis) > .7)
                {

                    //ChangeAnimationState("Woman1_WalkingSide");
                    ChangeAnimationState("PinkHairWoman_WalkingSide");
                    direction = PLAYER_HORIZONTAL;
                }
                // walking up
                if (yAxis > .7)
                {
                    //ChangeAnimationState("Woman1_WalkingBack");
                    ChangeAnimationState("PinkHairWoman_WalkingBack");
                    direction = PLAYER_UP;

                }
                // walking down
                if (yAxis < -.7)
                {
                    //ChangeAnimationState("Woman1_WalkingFront");
                    ChangeAnimationState("PinkHairWoman_WalkingFront");
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
                    //ChangeAnimationState("Woman1_IdleSide");
                    ChangeAnimationState("PinkHairWoman_IdleSide");

                }
                // idle facing back
                if(direction == PLAYER_UP)
                {
                    //ChangeAnimationState("Woman1_IdleBack");
                    ChangeAnimationState("PinkHairWoman_IdleBack");
                }
                // idle facing front
                if(direction == PLAYER_DOWN)
                {
                    ChangeAnimationState("PinkHairWoman_Idle");
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if(Selected_character == 2)
        {
            // MOVEMENT
            // move the player if the joystick is being moved
            if (movementJoystick.joystickVector.y != 0 || movementJoystick.joystickVector.x != 0)
            {
                rb.velocity = new Vector2(movementJoystick.joystickVector.x * playerSpeed, movementJoystick.joystickVector.y * playerSpeed);
                
                // ANIMATION
                // walking left/right
                if (Mathf.Abs(xAxis) > .7)
                {
                    ChangeAnimationState("LongBeardMan_WalkingSide");
                    direction = PLAYER_HORIZONTAL;
                }
                // walking up
                if (yAxis > .7)
                {
                    //ChangeAnimationState("Woman1_WalkingBack");
                    ChangeAnimationState("LongBeardMan_WalkingUp");
                    direction = PLAYER_UP;

                }
                // walking down
                if (yAxis < -.7)
                {
                    //ChangeAnimationState("Woman1_WalkingFront");
                    ChangeAnimationState("LongBeardMan_WalkingDown");
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
                    //ChangeAnimationState("Woman1_IdleSide");
                    ChangeAnimationState("LongBeardMan_IdleSide");

                }
                // idle facing back
                if(direction == PLAYER_UP)
                {
                    //ChangeAnimationState("Woman1_IdleBack");
                    ChangeAnimationState("LongBeardMan_IdleBack");
                }
                // idle facing front
                if(direction == PLAYER_DOWN)
                {
                    ChangeAnimationState("LongBeardMan_IdleSide");
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if(Selected_character == 3)
        {
           // MOVEMENT
            // move the player if the joystick is being moved
            if (movementJoystick.joystickVector.y != 0 || movementJoystick.joystickVector.x != 0)
            {
                rb.velocity = new Vector2(movementJoystick.joystickVector.x * playerSpeed, movementJoystick.joystickVector.y * playerSpeed);
                
                // ANIMATION
                // walking left/right
                if (Mathf.Abs(xAxis) > .7)
                {
                    ChangeAnimationState("ShortBeardMan_WalkingSide");
                    direction = PLAYER_HORIZONTAL;
                }
                // walking up
                if (yAxis > .7)
                {
                    //ChangeAnimationState("Woman1_WalkingBack");
                    ChangeAnimationState("ShortBeardMan_WalkingUp");
                    direction = PLAYER_UP;

                }
                // walking down
                if (yAxis < -.7)
                {
                    //ChangeAnimationState("Woman1_WalkingFront");
                    ChangeAnimationState("ShortBeardMan_WalkingDown");
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
                    //ChangeAnimationState("Woman1_IdleSide");
                    ChangeAnimationState("ShortBeardMan_IdleSide");

                }
                // idle facing back
                if(direction == PLAYER_UP)
                {
                    //ChangeAnimationState("Woman1_IdleBack");
                    ChangeAnimationState("ShortBeardMan_IdleBack");
                }
                // idle facing front
                if(direction == PLAYER_DOWN)
                {
                    ChangeAnimationState("ShortBeardMan_IdleSide");
                }
            } 
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if(Selected_character == 4)
        {
            if (movementJoystick.joystickVector.y != 0 || movementJoystick.joystickVector.x != 0)
            {
                rb.velocity = new Vector2(movementJoystick.joystickVector.x * playerSpeed, movementJoystick.joystickVector.y * playerSpeed);

                if (Mathf.Abs(xAxis) > .7)
                {
                    ChangeAnimationState("ManWithHat_WalkingSide");
                    direction = PLAYER_HORIZONTAL;
                }
                if (yAxis > .7)
                {
                    ChangeAnimationState("ManWithHat_WalkingUp");
                    direction = PLAYER_UP;
                }
                if (yAxis < -.7)
                {
                    ChangeAnimationState("ManWithHat_WalkingDown");
                    direction = PLAYER_DOWN;
                }
            }
            else
            {
                rb.velocity = Vector2.zero;

                if(direction == PLAYER_HORIZONTAL)
                {
                    ChangeAnimationState("ManWithHat_IdleSide");

                }
                if(direction == PLAYER_UP)
                {
                    ChangeAnimationState("ManWithHat_IdleBack");
                }
                if(direction == PLAYER_DOWN)
                {
                    ChangeAnimationState("ManWithHat_IdleSide");
                }
            } 
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if(Selected_character == 5)
        {
            if (movementJoystick.joystickVector.y != 0 || movementJoystick.joystickVector.x != 0)
            {
                rb.velocity = new Vector2(movementJoystick.joystickVector.x * playerSpeed, movementJoystick.joystickVector.y * playerSpeed);

                if (Mathf.Abs(xAxis) > .7)
                {
                    ChangeAnimationState("BrownHairMan_WalkingSide");
                    direction = PLAYER_HORIZONTAL;
                }
                if (yAxis > .7)
                {
                    ChangeAnimationState("BrownHairMan_WalkingUp");
                    direction = PLAYER_UP;
                }
                if (yAxis < -.7)
                {
                    ChangeAnimationState("BrownHairMan_WalkingDown");
                    direction = PLAYER_DOWN;
                }
            }
            else
            {
                rb.velocity = Vector2.zero;

                if(direction == PLAYER_HORIZONTAL)
                {
                    ChangeAnimationState("BrownHairMan_IdleSide");

                }
                if(direction == PLAYER_UP)
                {
                    ChangeAnimationState("BrownHairMan_IdleBack");
                }
                if(direction == PLAYER_DOWN)
                {
                    ChangeAnimationState("BrownHairMan_IdleSide");
                }
            } 
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
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
