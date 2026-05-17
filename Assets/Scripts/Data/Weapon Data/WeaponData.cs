using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Weapon Data", fileName = "New Weapon", order = 0)]
public class WeaponData : ScriptableObject
{
    public int damageOutput;
    public Mesh graphics;
}
