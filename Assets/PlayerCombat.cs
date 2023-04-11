using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 0.1f;
    public int bulletsPerShot = 1;
    public float bulletSpread = 0f;

    private float fireTimer = 0f;
    private bool isFiring;
    private BulletManager bulletManager;

    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    void Update()
    {
        // Sol click ile ateş et
        if (Input.GetMouseButton(0))
        {
            isFiring = true;
        }
        else
        {
            isFiring = false;
        }

        if (isFiring)
        {
            fireTimer -= Time.deltaTime;

            if (fireTimer <= 0f)
            {
                fireTimer = fireRate;
                Fire();
            }
        }
        else
        {
            fireTimer = 0f;
        }
    }

    void Fire()
    {
        for (int i = 0; i < bulletsPerShot; i++)
        {
            Vector3 direction = firePoint.forward;

            if (bulletSpread > 0f)
            {
                direction = Quaternion.Euler(Random.Range(-bulletSpread, bulletSpread), Random.Range(-bulletSpread, bulletSpread), 0f) * direction;
            }

            bulletManager.SpawnBullet(firePoint.position, Quaternion.LookRotation(direction));
        }
    }
}
