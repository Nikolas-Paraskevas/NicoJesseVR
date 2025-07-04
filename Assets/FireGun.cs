using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public GameObject prefab9mm_bullet;
    public GameObject BulletSpawner;

    public void Firebullet()
    {
        GameObject tempGO = Instantiate(prefab9mm_bullet, BulletSpawner.transform.position, this.transform.rotation);
        tempGO.GetComponent<Rigidbody>().velocity = -this.transform.right * 30f;
    }
}


