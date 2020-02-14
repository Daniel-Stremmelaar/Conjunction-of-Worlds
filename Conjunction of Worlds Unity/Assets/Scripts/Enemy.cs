using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] private int damage;
    [SerializeField] private int manaValue;
    private PlayerManager playerManager;
    private Transform targetLocation;
    private List<Tower> targetedByTowers = new List<Tower>();

    public void SetTarget(Transform target)
    {
        gameObject.GetComponent<NavMeshAgent>().SetDestination(target.position);
    }

    public void SetPlayerManager(PlayerManager manager)
    {
        playerManager = manager;
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            manaValue = 0;
            collision.gameObject.GetComponent<Character>().LoseHP(damage);
            Death();
        }
    }

    private void ClearSelfFromTowerTargets()
    {
        foreach(Tower t in targetedByTowers)
        {
            t.RemoveTarget(this);
        }
    }

    public override void Death()
    {
        ClearSelfFromTowerTargets();
        playerManager.GainMana(manaValue);
        base.Death();
    }

    public void TrackTargeting(Tower tower)
    {
        targetedByTowers.Add(tower);
    }
}
