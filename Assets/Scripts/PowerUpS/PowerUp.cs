using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerupEffect PowerupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);

            PowerupEffect.Apply(collision.gameObject);
        }
    }
}
