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
        PlayerHealth += amount;
        if (PlayerHealth > PlayerMaxHealth) 
        { 
            PlayerHealth = PlayerMaxHealth;
        }
    }
}
