using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   private Animator animator;

    [SerializeField] private int maxHealth = 100;

    private int currentHealth;

    private void Awake() => animator = GetComponent<Animator>();

    void Start() => currentHealth = maxHealth;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
            Die();        
    }

    void Die()
    {
        Debug.Log("Enemy died");

        // animator.SetBool("IsDead", true);

        //GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }

}
