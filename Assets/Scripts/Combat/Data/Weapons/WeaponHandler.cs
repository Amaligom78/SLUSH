using UnityEngine;

public class WeaponHandler : MonoBehaviour
{

    [SerializeField] private Weapon weaponLogic;


    public void EnableWeapon()
    {
        weaponLogic.Attack();
    }

    public void DisableWeapon()
    {
        weaponLogic.Disengage();
    }
}
