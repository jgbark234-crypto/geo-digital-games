using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    public Transform player;
    public float moveSpeed = 2.5f;
    public float stopDistance = 8f;

    [Header("Combat")]
    public float maxHealth = 100f;
    public float attackRange = 20f;
    public float fireCooldown = 1f;
    public float damage = 15f;

    private float currentHealth;
    private float nextFireTime;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (player == null) return;

        Vector3 toPlayer = player.position - transform.position;
        float distance = toPlayer.magnitude;

        Vector3 lookTarget = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookTarget);

        if (distance > stopDistance)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        bool canShoot = distance <= attackRange && Time.time >= nextFireTime;
        if (canShoot)
        {
            ShootPlayer();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    private void ShootPlayer()
    {
        ShieldSystem shield = player.GetComponent<ShieldSystem>();
        if (shield != null)
        {
            shield.TakeDamage(damage);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
