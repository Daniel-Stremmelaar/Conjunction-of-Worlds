using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform playerDruid;
    [SerializeField] private GameObject normalGiant;
    [SerializeField] private GameObject fireGiant;
    [SerializeField] private GameObject iceGiant;
    [SerializeField] private Transform spawnPoint;

    public enum Enemies
    {
        NormalGiant=1,
        FireGiant=2,
        IceGiant=3
    }

    public void PickMonster()
    {
        Enemies toSpawn = (Enemies) Random.Range(1, 4);
        switch (toSpawn)
        {
            case Enemies.NormalGiant:
                SpawnMonster(normalGiant, spawnPoint, playerDruid);
                break;
            case Enemies.FireGiant:
                SpawnMonster(fireGiant, spawnPoint, playerDruid);
                break;
            case Enemies.IceGiant:
                SpawnMonster(iceGiant, spawnPoint, playerDruid);
                break;
        }
    }

    private void SpawnMonster(GameObject monsterToSpawn, Transform spawnLocation, Transform target)
    {
        GameObject g = Instantiate(monsterToSpawn, spawnLocation);
        g.GetComponent<Enemy>().SetTarget(target);
    }
}
