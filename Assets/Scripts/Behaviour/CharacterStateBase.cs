using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateBase : StateMachineBehaviour
{
    // References to player interactons
    private PlayerMovement movement;
    private PlayerCombat combat;

    // A way for behaviour scripts to gain access to interaction scripts
    public PlayerMovement GetCharacterMovement(Animator animator)
    {
        if (movement == null)
            movement = animator.GetComponentInParent<PlayerMovement>();

        return movement;
    }

    public PlayerCombat GetCharacterCombat(Animator animator)
    {
        if (combat == null)
            combat = animator.GetComponentInParent<PlayerCombat>();

        return combat;
    }
}
