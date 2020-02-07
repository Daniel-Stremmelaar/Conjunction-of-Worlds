using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int hitPoints;

    public virtual void LoseHP(int damageTaken)
    {
        hitPoints -= damageTaken;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        
    }
}
