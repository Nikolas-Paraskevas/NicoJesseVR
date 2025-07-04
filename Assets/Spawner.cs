using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
       public GameObject objectToSpawn;

   public Transform spawnPosition;

   public int numberOfObjectToSpawn;

    private void Start()
    {
        for(int i= 0; i < numberOfObjectToSpawn; i++){

        Instantiate(objectToSpawn, spawnPosition.position, Quaternion.identity);
        }
    }
}
