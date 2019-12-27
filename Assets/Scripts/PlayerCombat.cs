using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    private bool canCombo = false;

    private void FixedUpdate()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Player_jump") || animator.GetCurrentAnimatorStateInfo(0).IsName("Player_fall"))
            animator.ResetTrigger("Attack");
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Play attack animation
            animator.SetTrigger("Attack");

            // Detect enemies in range of attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            Debug.Log("Attack triggered");


            // Damage them
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
