using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    public LayerMask ignoreLayer;
    public MeshFilter weaponGraphics;
    public Collider weaponCollider;

    private List<Collider> targetsHit = new List<Collider>();


    private void Awake()
    {
        weaponCollider.enabled = false;
    }

    private void OnEnable()
    {
        targetsHit.Clear();
    }

    public void AddWeapon(WeaponData _weaponData)
    {
        weaponData = _weaponData;
        weaponGraphics.sharedMesh = weaponData.graphics;
    }

    public void Attack()
    {
        weaponCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (targetsHit.Contains(other)) return;

        if(other.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            damagable.IDamage(weaponData.damageOutput);
            targetsHit.Add(other);
        }
    }

    public void Disengage()
    {
        targetsHit.Clear ();
        weaponCollider.enabled = false;
    }

    private void OnDisable()
    {
        weaponCollider.enabled = false;
    }
}
