using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifetime = 2.0f;
    public int damage = 1;

    private Rigidbody rb;
    private float timer = 0.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        damage = WeaponManager.CurrentGunData.damage;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        timer += Time.deltaTime;
        
        if (timer >= lifetime)
        {
            BulletManager.instance.ReturnBullet(this);
        }
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
        timer = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        // Enemy enemy = other.GetComponent<Enemy>();
        // if (enemy != null)
        // {
        //     enemy.TakeDamage(damage);
        //     Destroy(gameObject);
        // }
    }
}
