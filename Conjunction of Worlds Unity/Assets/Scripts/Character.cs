using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int hitPoints;

    public virtual void LoseHP(int damageTaken)
    {
        hitPoints -= damageTaken;
        if (hitPoints <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        
    }
}
