using System.Collections;
using UnityEngine;

// "PlayerHealth" sınıfı, oyuncunun canını yönetir.
public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("Can Ayarları")]
    [Tooltip("Maksimum can miktarı")]
    public int maxHealth = 100;
    [Tooltip("Hasar almadan önce geçmesi gereken süre")]
    public float timeToRegen = 5f;
    [Tooltip("Saniyede artış miktarı")]
    public int regenAmount = 5;

    private int currentHealth;
    private Coroutine regenCoroutine;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StopRegen();
            regenCoroutine = StartCoroutine(RegenHealth());
        }
    }

    public void Die()
    {
        // Oyuncunun ölümü ile ilgili işlemler
        Debug.Log("Player died");
    }

    private IEnumerator RegenHealth()
    {
        yield return new WaitForSeconds(timeToRegen);

        while (currentHealth < maxHealth)
        {
            currentHealth += regenAmount;
            yield return new WaitForSeconds(1f);
        }

        regenCoroutine = null;
    }

    private void StopRegen()
    {
        if (regenCoroutine != null)
        {
            StopCoroutine(regenCoroutine);
            regenCoroutine = null;
        }
    }
}