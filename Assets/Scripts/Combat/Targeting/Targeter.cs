using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup targetGroup;
    private List<Target> targets = new List<Target>();
    public Target currentTarget { get; private set; } = null;

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Target>(out Target target) && !targets.Contains(other.GetComponent<Target>()))
        {
            targets.Add(target);
            target.TargetDestroyedEvent += ClearTarget;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(targets.Contains(other.GetComponent<Target>()))
        {
            ClearTarget(other.GetComponent<Target>());
        }
    }

    public bool SelectTarget()
    {
        if (targets.Count == 0) return false;

        currentTarget = targets[0];
        targetGroup.AddMember(currentTarget.transform, 1f, 2f);
        return true;
    }

    public void ClearTarget()
    {
        targetGroup.RemoveMember(currentTarget.transform);
        currentTarget = null;
    }

    public void ClearTarget(Target _target)
    {
        if(currentTarget == _target)
        {
            targetGroup.RemoveMember(_target.transform);
            currentTarget = null;
        }

        _target.TargetDestroyedEvent -= ClearTarget;
        targets.Remove(_target);
    }
}
