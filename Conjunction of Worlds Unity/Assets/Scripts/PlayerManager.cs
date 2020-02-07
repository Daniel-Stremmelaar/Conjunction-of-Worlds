using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int mana;
    [SerializeField] private GameObject stoneSlingerTower;
    [SerializeField] private GameObject poisonNeedleTower;
    [SerializeField] private GameObject spikeEruptionTower;
    [SerializeField] private GameObject slowTower;
    private GameObject selectedBuildpoint;

    public enum Towers
    {
        StoneSlinger=1,
        PoisonNeedle=2,
        SpikeEruption=3,
        Slow=4
    }

    public void GainMana(int amountOfManaGained)
    {
        mana += amountOfManaGained;
    }

    public void LoseMana(int amountOfManaLost)
    {
        mana -= amountOfManaLost;
    }

    public void BuyTower(int towerIndex)
    {
        Towers tower = (Towers) towerIndex;
        switch (tower)
        {
            case Towers.StoneSlinger:
                break;
            case Towers.PoisonNeedle:
                break;
            case Towers.SpikeEruption:
                break;
            case Towers.Slow:
                break;
        }
    }

    private void BuildTower(GameObject towerToBuild)
    {
        if (towerToBuild.GetComponent<Tower>().GetManaCost() <= mana)
        {
            Tower t = Instantiate(towerToBuild, selectedBuildpoint.transform).GetComponent<Tower>();
            LoseMana(t.GetManaCost());
            t.Setup(this, selectedBuildpoint);
        }
    }
}