using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShotgun : MonoBehaviour
{
    public GameObject shotgun_bullet;
    public GameObject BulletSpawner;
    public AudioSource reloadSound;  // Assign in Inspector
    private bool canShoot = true;

    public void Firebullet()
    {
        if (canShoot)
        {
            // Shoot the shotgun
            GameObject tempGO = Instantiate(shotgun_bullet, BulletSpawner.transform.position, this.transform.rotation);

            // Start the cooldown process
            canShoot = false;
            StartCoroutine(ShotgunCooldown());
        }
    }

    private IEnumerator ShotgunCooldown()
    {
        yield return new WaitForSeconds(1f); // Wait 1 second, then play sound
        if (reloadSound != null)
        {
            reloadSound.Play();
        }

        yield return new WaitForSeconds(1f); // Wait another 1 second (total 2s cooldown)
        canShoot = true;
    }
}
