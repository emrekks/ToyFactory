using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int initialPoolSize = 10;

    private ObjectPool<TurretBullet> bulletPool;
    public static TurretBulletManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        bulletPool = new ObjectPool<TurretBullet>(bulletPrefab.GetComponent<TurretBullet>(), initialPoolSize);
    }

    public void FireBullet(Vector3 position, Quaternion rotation, float speed, float lifeTime)
    {
        TurretBullet bullet = bulletPool.GetObject();
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
        bullet.turretBulletSpeed = speed;
        bullet.turretBulletLifeTime = lifeTime;
        bullet.gameObject.SetActive(true);
    }

    public void ReturnBullet(TurretBullet bullet)
    {
        bulletPool.ReturnObject(bullet);
    }
}