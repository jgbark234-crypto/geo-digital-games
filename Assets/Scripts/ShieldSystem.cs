using UnityEngine;

public class ShieldSystem : MonoBehaviour
{
    [Header("Shield")]
    public float maxShield = 100f;
    public float regenerationPerSecond = 15f;
    public float regenerationDelay = 3f;

    [Header("Health")]
    public float maxHealth = 100f;

    public float CurrentShield { get; private set; }
    public float CurrentHealth { get; private set; }

    private float lastDamageTime;

    private void Start()
    {
        CurrentShield = maxShield;
        CurrentHealth = maxHealth;
        lastDamageTime = -regenerationDelay;
    }

    private void Update()
    {
        bool canRegenerate = Time.time >= lastDamageTime + regenerationDelay;
        if (canRegenerate && CurrentShield < maxShield)
        {
            CurrentShield += regenerationPerSecond * Time.deltaTime;
            CurrentShield = Mathf.Min(CurrentShield, maxShield);
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage <= 0f) return;

        lastDamageTime = Time.time;

        float remainingDamage = damage;

        if (CurrentShield > 0f)
        {
            float absorbed = Mathf.Min(CurrentShield, remainingDamage);
            CurrentShield -= absorbed;
            remainingDamage -= absorbed;
        }

        if (remainingDamage > 0f)
        {
            CurrentHealth -= remainingDamage;
            CurrentHealth = Mathf.Max(CurrentHealth, 0f);

            if (CurrentHealth <= 0f)
            {
                Debug.Log("Player is down!");
            }
        }
    }
}
