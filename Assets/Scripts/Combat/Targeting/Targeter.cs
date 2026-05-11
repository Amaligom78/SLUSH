using System;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    private List<Target> targets = new List<Target>();
    public Target currentTarget { get; private set; } = null;

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Target>(out Target target) && !targets.Contains(other.GetComponent<Target>()))
        {
            targets.Add(target);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(targets.Contains(other.GetComponent<Target>()))
        {
            targets.Remove(other.GetComponent<Target>());
        }
    }

    public bool SelectTarget()
    {
        if (targets.Count == 0) return false;

        currentTarget = targets[0];
        return true;
    }
}
