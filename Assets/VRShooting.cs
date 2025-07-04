using System.Collections;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;  // Het projectiel (kogel)
    public Transform firePoint;      // Het punt van waaruit de kogel wordt afgevuurd
    public float bulletSpeed = 20f;  // De snelheid van de kogel
    public float fireRate = 0.5f;   // Hoe snel het wapen kan schieten (in seconden)

    private float nextFireTime = 0f; // Tijd wanneer het volgende schot mag worden afgevuurd

    void Update()
    {
        // Schieten wanneer de speler op de linkermuisknop drukt
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Stel de volgende schootijd in
        }
    }

    void Shoot()
    {
        // Maak een nieuwe kogel
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Geef de kogel snelheid in de juiste richting
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed;
        }
    }
}