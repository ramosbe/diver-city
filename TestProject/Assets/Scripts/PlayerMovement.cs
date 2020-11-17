using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Respawn respawn;
    public float moveSpeed = 40f;
    public float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool hasJumped = false;
    bool alive = true;
    private float timerStart = 0.18f;
    public float timer;
    private float jumpForce;

    public Animator animator;
    private string currentState = PLAYER_IDLE;

    const string PLAYER_IDLE = "Player_Idle_Animation";
    const string PLAYER_RUN = "Player_Run_Animation";
    const string PLAYER_JUMP = "Player_Jump_Animation";
    const string PLAYER_CROUCH = "Player_Crouch_Animation";
    const string PLAYER_HURT = "Player_Hurt_Animation";

    private void Start()
    {
        animator = GetComponent<Animator>();
        timer = timerStart;
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        jumpForce = JumpCalc();
        alive = respawn.IsAlive();
        if (alive) //if player is alive do stuff
        {
            //animations
            if (crouch == false && controller.isGrounded()) //not crouch or and on ground
            {
                if (Input.GetButtonDown("Jump") && controller.isGrounded()) //change to jump animation
                {
                    jump = true;
                    ChangeAnimationState(PLAYER_JUMP);
                    hasJumped = true;
                    Invoke("ChangeJumpState", 0.1f);
                }
                if (!hasJumped) //if not jump, do idle or run
                {
                    if (horizontalMove == 0 && controller.isGrounded())
                    {
                        ChangeAnimationState(PLAYER_IDLE);
                    }
                    else if (horizontalMove != 0 && controller.isGrounded())
                    {
                        ChangeAnimationState(PLAYER_RUN);
                    }
                }
            }
            if (Input.GetButtonDown("Crouch") && controller.isGrounded()) //if crouch
            {
                crouch = true;
                ChangeAnimationState(PLAYER_CROUCH);
            }
            else if (Input.GetButtonUp("Crouch") && controller.canStand()) //if player can stand change idle
            {
                crouch = false;
                ChangeAnimationState(PLAYER_IDLE);
            }
            if (!Input.GetButton("Crouch") && controller.canStand()) //player moves to where they can stand, change to idle
            {
                crouch = false;
               // ChangeAnimationState(PLAYER_IDLE);
            }
        }
        else { //not alive
            ChangeAnimationState(PLAYER_HURT);
            
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, jumpForce);

    }

    //change animation state when called
    private void ChangeAnimationState(string newState)
    {
        if (currentState.Equals(newState)) return;

        animator.Play(newState);
        currentState = newState;
    }

    private void ChangeJumpState()
    {
        hasJumped = false;
    }

    //continuously add jump force that scales to 0 the longer jump is pressed
    private float JumpCalc()
    {
        if (Input.GetButton("Jump") && timer >= 0) 
        {
            timer -= Time.deltaTime * 2.7f;
            if (timer < 0)
                timer = 0;
        }else if (Input.GetButtonUp("Jump"))
        {
           //  timer = timerStart;
            jump = false;
        }
        if (controller.isGrounded())
        {
            Invoke("ResetTimer", 0.05f);
        }
        return timer;
    }

    private void ResetTimer()
    {
        timer = timerStart;
    }
}
