using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    private Transform targetLocation;

    public void SetTarget(Transform target)
    {
        gameObject.GetComponent<NavMeshAgent>().SetDestination(target.position);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
