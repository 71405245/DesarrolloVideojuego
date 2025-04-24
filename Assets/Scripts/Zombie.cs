using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed = 2f;
    private Transform player;

    public float damage = 10f; // Daño que causa el zombi

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;

            // Rotación hacia el jugador
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Llamamos a TakeDamage del jugador
            collision.gameObject.GetComponent<PlayerHealthBar>().TakeDamage(damage);
        }
    }

}
