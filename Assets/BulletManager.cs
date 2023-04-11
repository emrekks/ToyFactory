using System;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int initialPoolSize = 10;
    public static BulletManager instance;
    private ObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        bulletPool = new ObjectPool<Bullet>(bulletPrefab.GetComponent<Bullet>(), initialPoolSize);
    }

    public void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        Bullet bullet = bulletPool.GetObject();
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
    }

    public void ReturnBullet(Bullet bullet)
    {
        bulletPool.ReturnObject(bullet);
    }
}