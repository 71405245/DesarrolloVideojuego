using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float damage = 10f;
    public float attackCooldown = 1f; // 1 segundo entre golpes
    private float lastAttackTime = -999f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                PlayerHealthBar health = collision.gameObject.GetComponent<PlayerHealthBar>();
                if (health != null)
                {
                    Debug.Log("Golpe al jugador");
                    health.TakeDamage(damage);
                    lastAttackTime = Time.time;
                }
            }
        }
    }
}
