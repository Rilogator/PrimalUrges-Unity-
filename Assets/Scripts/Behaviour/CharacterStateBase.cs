using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateBase : StateMachineBehaviour
{
    // A reference to the character's controller
    private CharacterController2D controller;

    // Give this behaviour access to the controller script of our Character
    public CharacterController2D GetCharacterController(Animator animator)
    {
        if (controller == null)
            controller = animator.GetComponentInParent<CharacterController2D>();

        return controller;
    }
}
