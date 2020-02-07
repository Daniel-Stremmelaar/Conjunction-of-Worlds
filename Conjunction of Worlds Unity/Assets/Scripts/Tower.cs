using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int manaCost;
    [SerializeField] private float targetingRange;
    [SerializeField] private List<Enemy> targetsInRange = new List<Enemy>();
    private PlayerManager playerManager;
    private GameObject placement;

    public virtual void Setup(PlayerManager manager, GameObject buildPoint)
    {
        playerManager = manager;
        placement = buildPoint;
    }

    public virtual void SellTower()
    {
        playerManager.GainMana(Mathf.FloorToInt(manaCost/2));
        Destroy(gameObject);
    }

    public virtual int GetManaCost()
    {
        return manaCost;
    }
}