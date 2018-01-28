using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public float range;
    private NavMeshAgent agent;
    private SphereCollider col;
    private GameObject target;

    private int state; // 0 = idle, 1 = moving to target, 2 = attacking
    private Vector3 lastPosition;
    private float distanceFromTarget;


    // Use this for initialization
    void Start()
    {
        distanceFromTarget = 100f;
        lastPosition = new Vector3(0, 0, 0);
        agent = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
    }

    private void LateUpdate()
    {
        if (state == 0)
        {
            findTargets();
        }
    }

    private void moveToTarget()
    {
        state = 1;
        lastPosition = agent.transform.position;
        agent.SetDestination(target.transform.position);
    }

    private void idle()
    {
        state = 0;
        agent.SetDestination(lastPosition);
        findTargets();
    }

    private void findTargets()
    {
        Collider[] searchObjects = Physics.OverlapSphere(this.transform.position, range);
        int i = 0;

        if (searchObjects[i] != null)
        {
            while (i < searchObjects.Length)
            {
                if (searchObjects[i].GetComponent<entityManager>().getEntityType() == 0)
                {
                    target = searchObjects[i].gameObject;
                    distanceFromTarget = Vector3.Magnitude(target.transform.position - transform.position);
                }
                i += 1;
            }
        }

    }
}
