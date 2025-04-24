using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healAmount = 25f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthBar healthBar = other.GetComponent<PlayerHealthBar>();
            if (healthBar != null)
            {
                healthBar.Heal(healAmount);
                Destroy(gameObject); // Destruye el pickup después de recogerlo
            }
        }
    }
}
