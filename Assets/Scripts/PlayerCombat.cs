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

    public void Attack(InputAction.CallbackContext context)
    {
        //Play attack animation
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_idle") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Player_attack") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Player_attack_heavy") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Player_run"))
            animator.SetTrigger("Attack");
    }

    public void Damage(float damage)
    {
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Debug.Log("Attack triggered");

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
