using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject[] zombiePrefabs; // 0 = normal, 1 = fuerte, 2 = tanque
    public float spawnInterval = 2f;
    public float spawnRadius = 10f;

    private int tankZombieCount = 0;
    public int maxTankZombies = 2;

    void Start()
    {
        InvokeRepeating("SpawnZombie", 1f, spawnInterval);
    }

    void SpawnZombie()
    {
        Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle.normalized * spawnRadius;

        GameObject prefabToSpawn;

        float randomValue = Random.Range(0f, 1f);

        if (randomValue <= 0.7f)
        {
            // 70% chance de zombi normal
            prefabToSpawn = zombiePrefabs[0];
        }
        else if (randomValue <= 0.95f)
        {
            // 25% chance de zombi fuerte
            prefabToSpawn = zombiePrefabs[1];
        }
        else
        {
            // 5% chance de zombi tanque, pero limitado a 2
            if (tankZombieCount < maxTankZombies)
            {
                prefabToSpawn = zombiePrefabs[2];
                tankZombieCount++;
            }
            else
            {
                // Si ya salieron 2 tanques, cambia a fuerte
                prefabToSpawn = zombiePrefabs[1];
            }
        }

        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }
}
