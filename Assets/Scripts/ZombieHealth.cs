using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
    public Image healthBarImage;
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBarImage != null)
            healthBarImage.fillAmount = currentHealth / maxHealth;
    }

    void Die()
    {
        FindFirstObjectByType<ZombieKillCounter>()?.AddKill();
        Destroy(gameObject);
    }

}
