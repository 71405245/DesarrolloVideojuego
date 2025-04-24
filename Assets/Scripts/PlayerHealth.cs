using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public GameObject gameOverPanel; // Asigna este panel en el Inspector
    public float maxHealth = 100f;
    private float currentHealth;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // Asegúrate que empiece oculto
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        UpdateHealthBar();
        Debug.Log("Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (isDead) return;

        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateHealthBar();
        Debug.Log("Curado: " + amount);
    }

    void UpdateHealthBar()
    {
        healthBarImage.fillAmount = currentHealth / maxHealth;
        Debug.Log("Actualizando barra: " + (currentHealth / maxHealth));
    }

    void Die()
    {
        isDead = true;
        Debug.Log("¡El jugador ha muerto!");

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // Desactivar scripts de control
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerShooting>().enabled = false;

        // (Opcional) Animación o sonido de muerte
    }
}
