using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public bool destroyOnDeath = true;
    public int maxHealth = 3;
    private int currentHealth;
    public HudScript healthBarMove;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) 
        { 
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBarMove.decreaseHealthBar(amount);
        Debug.Log($"{name} took {amount} dmg. HP: {currentHealth}/{maxHealth}");
        if (currentHealth <= 0)
        {
            if (destroyOnDeath)
            {
                Die();
            }
            Debug.Log($"{name} died");
            // TODO: respawn / game over / disable controls
        }
    }
    
    private void Die()
    {
        // TODO: effect / sound 
        if (destroyOnDeath) Destroy(gameObject);
        else gameObject.SetActive(false);
    }
}
