using UnityEngine;

public class Health : MonoBehaviour
{
    public int PlayerHealth;
    public int PlayerMaxHealth = 3;

    private void Start()
    {
        PlayerHealth = PlayerMaxHealth;
    }

    public void Heal(int amount)
    {
<<<<<<< Updated upstream
        PlayerHealth += amount;
        if (PlayerHealth > PlayerMaxHealth) 
=======
        currentHealth += amount;
        if (currentHealth > maxHealth)
>>>>>>> Stashed changes
        { 
            PlayerHealth = PlayerMaxHealth;
        }
    }
}
