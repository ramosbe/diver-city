using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float moveSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool hasJumped = false;

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
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (crouch == false && controller.isGrounded())
        {
            if (Input.GetButtonDown("Jump") && controller.isGrounded())
            {
                jump = true;
                ChangeAnimationState(PLAYER_JUMP);
                hasJumped = true;
                Invoke("ChangeJumpState", 0.05f);
            }
            if (!hasJumped) 
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
        if (Input.GetButtonDown("Crouch") && controller.isGrounded())
        {
            crouch = true;
            ChangeAnimationState(PLAYER_CROUCH);
        } else if (Input.GetButtonUp("Crouch") && controller.canStand())
        {
            crouch = false;
            ChangeAnimationState(PLAYER_IDLE);
        }
        if (!Input.GetButton("Crouch") && controller.canStand())
        {
            crouch = false;
            ChangeAnimationState(PLAYER_IDLE);
        }

    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState.Equals(newState)) return;

        animator.Play(newState);
        currentState = newState;
    }
    private void ChangeJumpState()
    {
        hasJumped = false;
    }
}
