using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    private Weapon oldWeapon;
    GameObject currentWeaponObject;
    [SerializeField] private GameObject weaponSlot;
    [SerializeField] private Slider ammoSlider;

    private void Update()
    {
        if (currentWeapon != null)
        {
            ammoSlider.gameObject.SetActive(true);
            ammoSlider.maxValue = currentWeapon.GetMaxAmmo();
            ammoSlider.value = currentWeapon.GetCurrentAmmo();
        }
        else
        {
            ammoSlider.gameObject.SetActive(false);
        }


        if (currentWeapon != null)
        {
            CheckAmmoAndDestroy();
        }
    }

    public void GiveWeapon(GameObject weaponObject)
    {
        if (currentWeaponObject != null)
        {
            Destroy(currentWeaponObject);
        }

        currentWeaponObject = Instantiate(weaponObject, weaponSlot.transform);
        currentWeapon = currentWeaponObject.GetComponent<Weapon>();
        oldWeapon = currentWeapon;
    }

    public bool HasWeapon()
    {
        return currentWeapon != null;
    }

    private void CheckAmmoAndDestroy()
    {
        if (!currentWeapon.HasAmmo())
        {
            currentWeapon = null;
        }
    }

    public void RefreshOldWeapon()
    {
        currentWeapon = oldWeapon;
    }

    public Weapon GetCurrentWeapon()
    {
        return currentWeapon;
    }

    public Weapon GetOldWeapon()
    {
        return oldWeapon;
    }
}