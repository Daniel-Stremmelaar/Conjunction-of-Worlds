using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : Tower
{
    [SerializeField] private int damage;
    [SerializeField] private float attackTime;
    private float attackTimer;

    private void Start()
    {
        attackTimer = attackTime;
    }

    private void Update()
    {
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else
        {
            Attack();
        }
    }

    public virtual void Attack()
    {
        if(currentTarget != null)
        {
            currentTarget.LoseHP(damage);
            attackTimer = attackTime;
        }
    }
}
