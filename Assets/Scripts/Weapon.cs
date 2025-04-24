using UnityEngine;

[System.Serializable]
public class Weapon
{
    public string weaponName;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    public int bulletsPerShot = 1; // ← Esta línea es importante
    public AudioClip fireSound;
    [HideInInspector] public AudioSource audioSource;
}
