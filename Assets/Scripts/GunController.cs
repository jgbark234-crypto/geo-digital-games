using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Gun")]
    public int magazineSize = 12;
    public float fireRate = 0.2f;
    public float reloadTime = 1.5f;
    public float range = 100f;
    public float damage = 25f;

    [Header("References")]
    public Camera playerCamera;

    private int currentAmmo;
    private bool isReloading;
    private float nextTimeToFire;

    private void Start()
    {
        currentAmmo = magazineSize;
    }

    private void Update()
    {
        if (isReloading) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        currentAmmo--;

        if (playerCamera == null)
        {
            Debug.LogWarning("GunController needs a camera reference.");
            return;
        }

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            EnemyController enemy = hit.collider.GetComponentInParent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    private IEnumerator Reload()
    {
        if (isReloading) yield break;

        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magazineSize;
        isReloading = false;
        Debug.Log("Reload complete");
    }
}
