using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10f;
    public float explosionRadius = 5f;  // Radio de explosi�n
    public float damage = 100f;         // Da�o de la explosi�n
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;  // Mover el cohete
        Destroy(gameObject, 5f);  // Destruir despu�s de 5 segundos si no explota
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Explosi�n al impactar
        Explode();
    }

    void Explode()
    {
        // Buscar todos los objetos en el radio de explosi�n
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Zombie"))
            {
                ZombieHealth health = enemy.GetComponent<ZombieHealth>();
                if (health != null)
                {
                    health.TakeDamage(damage);  // Hacer da�o a los zombis en el �rea
                }
            }
        }

        // Crear un efecto de explosi�n (puedes agregar part�culas si lo deseas)
        Destroy(gameObject);  // Destruir el proyectil despu�s de la explosi�n
    }
}
