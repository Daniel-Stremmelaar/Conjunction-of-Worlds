using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPoint : MonoBehaviour
{
    private BuildPoint nextBuildpoint;
    private BuildPoint lastBuildpoint;
    [SerializeField] private Light lightPoint;

    public void SetBuildpoints(BuildPoint next, BuildPoint last)
    {
        nextBuildpoint = next;
        lastBuildpoint = last;
    }

    public BuildPoint GetNextBuildpoint()
    {
        return nextBuildpoint;
    }

    public BuildPoint GetLastBuildpoint()
    {
        return lastBuildpoint;
    }

    public void ToggleLight(bool active)
    {
        lightPoint.enabled = active;
    }
}
