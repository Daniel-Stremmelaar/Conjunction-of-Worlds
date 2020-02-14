using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int manaCost;
    [SerializeField] private float targetingRange;
    [SerializeField] private List<Enemy> targetsInRange = new List<Enemy>();
    [SerializeField] private BuildPoint buildPoint;
    public Enemy currentTarget;
    private PlayerManager playerManager;
    private GameObject placement;

    public virtual void Setup(PlayerManager manager, GameObject buildPoint)
    {
        playerManager = manager;
        placement = buildPoint;
        GetComponent<SphereCollider>().radius = targetingRange;
    }

    public virtual void SellTower()
    {
        playerManager.GainMana(Mathf.FloorToInt(manaCost/2));
        Instantiate(buildPoint, transform);
        playerManager.AddBuildpoint(buildPoint);
        Destroy(gameObject);
    }

    public virtual int GetManaCost()
    {
        return manaCost;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            targetsInRange.Add(other.gameObject.GetComponent<Enemy>());
            if(other.gameObject.GetComponent<Enemy>() != currentTarget)
            {
                currentTarget = other.gameObject.GetComponent<Enemy>();
            }
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            RemoveTarget(other.gameObject.GetComponent<Enemy>());
        }
    }

    public void RemoveTarget(Enemy enemy)
    {
        targetsInRange.Remove(enemy);
        currentTarget = targetsInRange[0];
    }
}