using JetBrains.Annotations;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float attackDistance = 5f;
    [SerializeField] private float attackInterval = 1f;

    [CanBeNull] private Transform player;
    private TurretBulletManager bulletManager;

    private float attackTimer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bulletManager = FindObjectOfType<TurretBulletManager>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            // Look at the player
            Vector3 direction = player.position - transform.position;
            direction.y = 0f;
            transform.rotation = Quaternion.LookRotation(direction);

            attackTimer += Time.deltaTime;

            if (attackTimer >= attackInterval)
            {
                bulletManager.FireBullet(transform.position, transform.rotation, 10f, 2f);
                attackTimer = 0f;
            }
        }
        else
        {
            attackTimer = 0f;
        }
    }
}