using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public LayerMask ignoreLayer;
    public int damageOutput;

    private List<Collider> targetsHit = new List<Collider>();

    private void OnEnable()
    {
        targetsHit.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (targetsHit.Contains(other)) return;

        if(other.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            damagable.IDamage(damageOutput);
            targetsHit.Add(other);
        }
    }
}
