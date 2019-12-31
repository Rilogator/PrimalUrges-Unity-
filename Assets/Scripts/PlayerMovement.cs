using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{   
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    Vector2 moveDirection = Vector2.zero;
    bool jump = false;
    bool crouch = false;


    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>() * runSpeed;
        

        animator.SetFloat("Speed", Mathf.Abs(moveDirection.magnitude));
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
            controller.Move(moveDirection * Time.fixedDeltaTime, crouch, jump);

        jump = false;
    }
}