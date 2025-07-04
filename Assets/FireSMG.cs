using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSMG : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Renamed to avoid ambiguity
    [SerializeField] private Transform bulletSpawner; // Changed type to Transform for clarity
    [SerializeField] private float fireRate = 0.1f; // Adjustable fire rate
    [SerializeField] private AudioSource bulletSound;
    [SerializeField] private ParticleSystem bulletParticleSystem;
    private bool isFiring = false;

    private void Update()
    {

    }

    public void StartFiring()
    {
        if (!isFiring)
        {
            isFiring = true;
            InvokeRepeating(nameof(FireBullet), 0f, fireRate);
        }
    }

    public void StopFiring()
    {
        isFiring = false;
        CancelInvoke(nameof(FireBullet));
    }

    private void FireBullet()
    {
        if (bulletPrefab != null && bulletSpawner != null)
        {
            GameObject tempGO = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
            Rigidbody rb = tempGO.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = bulletSpawner.right * 50f; // Fixed direction
            }

            if (bulletSound != null)
            {
                bulletSound.Play();
            }

            if (bulletParticleSystem != null)
            {
                bulletParticleSystem.Play();
            }

        }
    }
}
