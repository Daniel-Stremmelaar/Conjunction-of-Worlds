using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerManager manager;
    [SerializeField] private Spawner spawner;
    [SerializeField] private float spawnTime;
    private float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnTime;
    }

    private void Update()
    {
        if(spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawner.PickMonster();
            spawnTimer = spawnTime;
        }
    }
}
