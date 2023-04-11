using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<Weapon> weapons; 
    public int maxHavingWeaponCount;
    public Weapon currentWeapon;
    public int currentWeaponIndex = 0;
    
    public static WeaponData CurrentGunData; 
    
    void Start()
    {
        EquipWeapon(currentWeaponIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
    }

    void SwitchWeapon(int index)
    {
        if (index >= 0 && index < maxHavingWeaponCount && index != currentWeaponIndex)
        {
            EquipWeapon(index);
        }
    }

    void EquipWeapon(int index)
    {
        if (currentWeapon != null)
        {
            UnequipWeapon(currentWeapon);
        }

        currentWeaponIndex = index;
        
        weapons[index].gameObject.SetActive(true);

        CurrentGunData = weapons[index].weaponData;

        CurrentGunData.currentAmmo = CurrentGunData.maxAmmo; 

        currentWeapon = weapons[index];
    }

    void UnequipWeapon(Weapon oldWeapon)
    {
        oldWeapon.gameObject.SetActive(false);
    }
}
