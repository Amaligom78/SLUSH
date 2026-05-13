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
        if (!other.TryGetComponent(out Target target)) return;
        if (targets.Contains(target)) return;

        targets.Add(target);
        target.TargetDestroyedEvent += ClearTarget;
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out Target target)) return;
        if (!targets.Contains(target)) return;

        ClearTarget(target);
    }

    public bool SelectTarget()
    {
        if (currentTarget != null) return true;
        if (targets.Count == 0) return false;

        currentTarget = targets[0];
        targetGroup.AddMember(currentTarget.transform, 1f, 2f);

        return true;
    }

    public void ClearTarget()
    {
        if (currentTarget == null) return;

        targetGroup.RemoveMember(currentTarget.transform);
        currentTarget = null;
    }

    public void ClearTarget(Target target)
    {
        if (target == null) return;

        if (currentTarget == target)
        {
            targetGroup.RemoveMember(target.transform);
            currentTarget = null;
        }

        target.TargetDestroyedEvent -= ClearTarget;
        targets.Remove(target);
    }
}
