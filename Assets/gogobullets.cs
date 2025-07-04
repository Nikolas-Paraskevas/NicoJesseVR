using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gogobullets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = this.transform.forward * 30f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
