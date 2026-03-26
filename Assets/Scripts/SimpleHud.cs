using UnityEngine;
using UnityEngine.UI;

public class SimpleHud : MonoBehaviour
{
    public ShieldSystem shieldSystem;
    public Text shieldText;
    public Text healthText;

    private void Update()
    {
        if (shieldSystem == null) return;

        if (shieldText != null)
        {
            shieldText.text = $"Shield: {Mathf.CeilToInt(shieldSystem.CurrentShield)}";
        }

        if (healthText != null)
        {
            healthText.text = $"Health: {Mathf.CeilToInt(shieldSystem.CurrentHealth)}";
        }
    }
}
