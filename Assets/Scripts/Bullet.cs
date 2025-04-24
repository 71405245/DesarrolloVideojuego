using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;
    public float damage = 25f;  // Variable de daño de la bala

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed;  // Cambié linearVelocity a velocity (por defecto se usa Rigidbody2D.velocity)
        transform.right = rb.linearVelocity.normalized;
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            // Accedemos al script de salud del zombi
            ZombieHealth health = collision.gameObject.GetComponent<ZombieHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);  // Usamos el daño definido en la bala
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
