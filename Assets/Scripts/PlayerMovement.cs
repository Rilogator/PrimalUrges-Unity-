using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{   
    // shared namespace for PlayerMovement?
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

    public void onJump()
    {
        jump = true;
        animator.SetBool("isJumping", true);
    }

    public void OnLanding ()
    {
        animator.SetBool("isJumping", false);
    }
       
    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}