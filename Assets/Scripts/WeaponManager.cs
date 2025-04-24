using UnityEngine;  // Asegúrate de tener esta línea

public class WeaponManager : MonoBehaviour
{
    public Transform firePoint;
    public Weapon[] weapons;
    public int currentWeaponIndex = 0;
    private float nextFireTime;

    void Start()
    {
        foreach (Weapon weapon in weapons)
        {
            GameObject audioObj = new GameObject("Audio_" + weapon.weaponName);
            audioObj.transform.SetParent(transform);
            weapon.audioSource = audioObj.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Cambiar de arma
        {
            SwitchWeapon();
        }

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime) // Disparar
        {
            Fire();
        }
    }

    void Fire()
    {
        if (weapons.Length == 0)
        {
            Debug.LogError("No weapons assigned in the WeaponManager!");
            return;
        }

        Weapon currentWeapon = weapons[currentWeaponIndex];
        nextFireTime = Time.time + currentWeapon.fireRate;

        for (int i = 0; i < currentWeapon.bulletsPerShot; i++)
        {
            Instantiate(currentWeapon.bulletPrefab, firePoint.position, firePoint.rotation);
        }

        // 🎵 Reproducir el sonido de disparo si está asignado
        if (currentWeapon.fireSound != null && currentWeapon.audioSource != null)
        {
            currentWeapon.audioSource.PlayOneShot(currentWeapon.fireSound);
        }
    }


    void SwitchWeapon()
    {
        if (weapons.Length == 0)
        {
            Debug.LogError("No weapons to switch to!");
            return;
        }

        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;  // Cambiar de arma
        Debug.Log("Arma actual: " + weapons[currentWeaponIndex].weaponName);
    }
}
