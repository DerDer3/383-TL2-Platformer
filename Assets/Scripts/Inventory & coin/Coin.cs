using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinData coinData;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Inventory inventory = other.GetComponent<Inventory>();
        
        if(inventory != null)
        {
            inventory.AddCoin(coinData.value);
            Destroy(gameObject);
        }
    }
}
