using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{   
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;


    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalMove = context.ReadValue<Vector2>().x * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
    }

    public void OnLanding ()
    {
        animator.SetBool("isJumping", false);
    }
       
    void FixedUpdate()
    {
        // Move our character
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_idle") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Player_run") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Player_jump") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Player_fall")

            )
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;
    }
}