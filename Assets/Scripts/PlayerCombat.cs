using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform firePoint;
   
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
        if (Input.GetKeyUp(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
        
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
                fireTimer = WeaponManager.CurrentGunData.fireRate;
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
        if (WeaponManager.CurrentGunData.currentAmmo > 0)
        {
            for (int i = 0; i < WeaponManager.CurrentGunData.bulletsPerShot; i++)
            {
                Vector3 direction = firePoint.forward;

                if (bulletSpread > 0f)
                {
                    direction = Quaternion.Euler(Random.Range(-bulletSpread, bulletSpread), Random.Range(-bulletSpread, bulletSpread), 0f) * direction;
                }

                bulletManager.SpawnBullet(firePoint.position, Quaternion.LookRotation(direction));

                WeaponManager.CurrentGunData.currentAmmo--;
            }
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    
    IEnumerator Reload()
    {
        //AnimationStart
        
        yield return new WaitForSeconds(WeaponManager.CurrentGunData.reloadTime);

        WeaponManager.CurrentGunData.currentAmmo = WeaponManager.CurrentGunData.maxAmmo;
    }
}
