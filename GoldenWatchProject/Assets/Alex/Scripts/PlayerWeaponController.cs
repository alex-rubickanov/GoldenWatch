using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    GameObject currentWeaponObject;
    [SerializeField] private GameObject weaponSlot;

    private void Update()
    {
        if(currentWeapon != null) {
            CheckAmmoAndDestroy();
        }
        
    }

    public void GiveWeapon(GameObject weaponObject)
    {
        if(currentWeapon == null) {
            if(currentWeaponObject != null) {
                Destroy(currentWeaponObject);
            }
            currentWeaponObject = Instantiate(weaponObject, weaponSlot.transform);
            currentWeapon = currentWeaponObject.GetComponent<Weapon>();
            
        }
        
    }
    public bool HasWeapon()
    {
        return currentWeapon != null;
    }

    private void CheckAmmoAndDestroy()
    {
        if (!currentWeapon.HasAmmo()) {
            currentWeapon = null;
        }
    }
}
