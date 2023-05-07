using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2f;

    private Rigidbody rb;
    private float _turretBulletSpeed;

    public float turretBulletLifeTime { get => lifeTime; set => lifeTime = value; }
    public float turretBulletSpeed { get => _turretBulletSpeed; set => _turretBulletSpeed = value; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.velocity = transform.forward * _turretBulletSpeed;
        Invoke(nameof(Deactivate), lifeTime);
    }

    private void Deactivate()
    {
        TurretBulletManager.instance.ReturnBullet(this);
        gameObject.SetActive(false);
    }
}