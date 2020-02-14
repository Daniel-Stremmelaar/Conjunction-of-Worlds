using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] List<BuildPoint> buildPoints = new List<BuildPoint>();
    [SerializeField] private int mana;
    [SerializeField] private GameObject stoneSlingerTower;
    [SerializeField] private GameObject poisonNeedleTower;
    [SerializeField] private GameObject spikeEruptionTower;
    [SerializeField] private GameObject slowTower;
    private BuildPoint selectedBuildpoint;

    private void Start()
    {
        for(int i = 0; i < buildPoints.Count; i++)
        {
            if(i == 0)
            {
                buildPoints[i].SetBuildpoints(buildPoints[i + 1], buildPoints[buildPoints.Count - 1]);
            }
            else if (i == buildPoints.Count - 1)
            {
                buildPoints[i].SetBuildpoints(buildPoints[0], buildPoints[i - 1]);
            }
            else
            {
                buildPoints[i].SetBuildpoints(buildPoints[i + 1], buildPoints[i - 1]);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (selectedBuildpoint != null)
            {
                SelectBuildpoint(selectedBuildpoint.GetLastBuildpoint());
            }
            else
            {
                SelectBuildpoint(buildPoints[0]);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (selectedBuildpoint != null)
            {
                SelectBuildpoint(selectedBuildpoint.GetNextBuildpoint());
            }
            else
            {
                SelectBuildpoint(buildPoints[0]);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            BuildTower(stoneSlingerTower);
        }
    }

    public void SelectBuildpoint(BuildPoint buildPoint)
    {
        foreach(BuildPoint b in buildPoints)
        {
            b.ToggleLight(false);
        }
        selectedBuildpoint = buildPoint;
        selectedBuildpoint.ToggleLight(true);
    }

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
            t.Setup(this, selectedBuildpoint.gameObject);

            buildPoints.Remove(selectedBuildpoint);
            Destroy(selectedBuildpoint);
        }
    }

    public void AddBuildpoint(BuildPoint point)
    {
        buildPoints.Add(point);
    }
}