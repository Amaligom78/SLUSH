using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    public Camera mainCamera { get; private set; }
    [SerializeField] private CinemachineTargetGroup targetGroup;
    private List<Target> targets = new List<Target>();
    public Target currentTarget { get; private set; } = null;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

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

        Target closestTarget = null;
        float closestTargetDistance = Mathf.Infinity;

        foreach (Target target in targets)
        {
            Vector2 viewPOS = mainCamera.WorldToViewportPoint(target.transform.position);

            if (viewPOS.x < 0 || viewPOS.x > 1 || viewPOS.y < 0 || viewPOS.y > 1) continue;

            Vector2 toCenter = viewPOS - new Vector2(0.5f, 0.5f);

            if(toCenter.sqrMagnitude < closestTargetDistance)
            {
                closestTarget = target;
                closestTargetDistance = toCenter.sqrMagnitude;
            }
        }

        if(closestTarget == null) return false;

        currentTarget = closestTarget;
        targetGroup.AddMember(currentTarget.transform, 1f, 2f);

        return true;
    }

    public void StopTargeting()
    {
        currentTarget = null;
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
