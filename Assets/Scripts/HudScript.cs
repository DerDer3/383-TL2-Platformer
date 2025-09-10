using UnityEngine;
using UnityEngine.UI;

public class HudScript : MonoBehaviour
{
    [SerializeField]
    private Slider healthBarAmount;

    void Start()
    {
        healthBarAmount.maxValue = 3;
        healthBarAmount.value = 3;
    }

    public void decreaseHealthBar(int amount)
    {
        Debug.Log("Decreasing Health Bar(Ouch!)");
        healthBarAmount.value -= amount;
    }
}
