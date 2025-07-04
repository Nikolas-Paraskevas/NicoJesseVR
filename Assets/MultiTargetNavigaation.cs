using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class MultiTargetNavigation : MonoBehaviour
{
    public NavMeshAgent nma;
    public List<GameObject> targets = new List<GameObject>();
    public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        nma.SetDestination(targets[counter].transform.position);

        Vector3 targetDistance = targets[counter].transform.position - transform.position;
        Debug.Log(targetDistance.magnitude);
        if (targetDistance.magnitude < 2f)
        {
            counter++;
            if (counter >= targets.Count)
            {
                counter = 0;
            }
        }
    }
}
