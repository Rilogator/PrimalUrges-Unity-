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

    private InputMaster controls = null;

    private void Awake() => controls = new InputMaster();

    private void OnEnable() => controls.Player.Enable();

    private void OnDisable() => controls.Player.Disable();

    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    moveDirection = context.ReadValue<Vector2>() * runSpeed;        

    //    animator.SetFloat("Speed", Mathf.Abs(moveDirection.magnitude));
    //}

    //public void OnJump(InputAction.CallbackContext context)
    //{
    //        jump = true;
    //        animator.SetBool("isJumping", true);
    //}

    public void OnLanding ()
    {
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate()
    {
        moveDirection = controls.Player.Move.ReadValue<Vector2>().normalized * runSpeed;
        
        animator.SetFloat("Speed", Mathf.Abs(moveDirection.magnitude));

        // Move our character
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_idle") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Player_run") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Player_jump") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Player_fall"))
        {
            controller.Move(moveDirection * Time.fixedDeltaTime, crouch, jump);
        }
        jump = false;
    }
}