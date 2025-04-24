using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 10f;

    void Start()
    {
        InvokeRepeating("SpawnZombie", 1f, spawnInterval);
    }

    void SpawnZombie()
    {
        Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
    }
}
