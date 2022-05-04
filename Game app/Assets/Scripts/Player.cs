using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[RequireComponent(typeof(AudioSource))]

// Player Script
public class Player : MonoBehaviour
{
    public JoystickMovement movementJoystick;
    public float playerSpeed;
    public Animator animator;
    public static int Selected_character;

    private Rigidbody2D rb;
    private string currentAnimaton;
    private string currentFootstepState;
    private float xAxis;
    private float yAxis;
    private float direction;


    // Animation player directions
    const float PLAYER_HORIZONTAL = 1;
    const float PLAYER_UP = 2;
    const float PLAYER_DOWN = 3;

    public AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        // fetch rb2D from the game object
        rb = GetComponent<Rigidbody2D>();
        //fetch animator component
        animator = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();

        // Gets selected character from SkinManager
    
        Selected_character = SkinManager.character_choice;
        //Debug.Log("Selected_character = " + Selected_character);
        DefaultAnimationStates();


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
                FootstepsManager("Walking");
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
                FootstepsManager("Idle");

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

        // changes the spite animation depending on which player the user chose in the character selection scene
        if(Selected_character == 0)
        {
            CharacterMovement("Woman1_WalkingSide","Woman1_WalkingBack","Woman1_WalkingFront","Woman1_IdleSide","Woman1_IdleBack","Woman1_IdleFront");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if(Selected_character == 1) 
        {
            CharacterMovement("PinkHairWoman_WalkingSide","PinkHairWoman_WalkingBack","PinkHairWoman_WalkingFront","PinkHairWoman_IdleSide","PinkHairWoman_IdleBack","PinkHairWoman_Idle");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if(Selected_character == 2)
        {
            CharacterMovement("LongBeardMan_WalkingSide","LongBeardMan_WalkingUp","LongBeardMan_WalkingDown","LongBeardMan_IdleSide","LongBeardMan_IdleBack","LongBeardMan_IdleFront");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if(Selected_character == 3)
        {
            CharacterMovement("ShortBeardMan_WalkingSide","ShortBeardMan_WalkingUp","ShortBeardMan_WalkingDown","ShortBeardMan_IdleSide","ShortBeardMan_IdleBack","ShortBeardMan_IdleFront");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if(Selected_character == 4)
        {
            CharacterMovement("ManWithHat_WalkingSide","ManWithHat_WalkingUp","ManWithHat_WalkingDown","ManWithHat_IdleSide","ManWithHat_IdleBack","ManWithHat_IdleFront");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if(Selected_character == 5)
        {
            CharacterMovement("BrownHairMan_WalkingSide","BrownHairMan_WalkingUp","BrownHairMan_WalkingDown","BrownHairMan_IdleSide","BrownHairMan_IdleBack","BrownHairMan_IdleFront");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else
        {
            CharacterMovement("Woman1_WalkingSide","Woman1_WalkingBack","Woman1_WalkingFront","Woman1_IdleSide","Woman1_IdleBack","Woman1_IdleFront");
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

    // footstep manager function
    void FootstepsManager(string newState)
    {
        // checks if the passed in string is the same as the current state
        if (currentFootstepState == newState) return;

        // if the passed in string is "Walking" then play the walking audio
        if (newState == "Walking")
        {
            audioSrc.Play();
        }
        // if the passed in string is "Idle" then stop the walking audio
        if (newState == "Idle")
        {
            audioSrc.Stop();
        }

        // updates the current state to the passed in state
        currentFootstepState = newState;
    }

    // sets the default animation state depending on which character the user chose in the character selection scene
    void DefaultAnimationStates()
    {
        if (Selected_character == 0)
        {
            ChangeAnimationState("Woman1_IdleFront");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if (Selected_character == 1)
        {
            ChangeAnimationState("PinkHairWoman_Idle");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if (Selected_character == 2)
        {
            ChangeAnimationState("LongBeardMan_IdleFront");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if (Selected_character == 3)
        {
            ChangeAnimationState("ShortBeardMan_IdleFront");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if (Selected_character == 4)
        {
            ChangeAnimationState("ManWithHat_IdleFront");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else if (Selected_character == 5)
        {
            ChangeAnimationState("BrownHairMan_IdleFront");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        else
        {
            ChangeAnimationState("Woman1_IdleFront");
        }
    }
}
