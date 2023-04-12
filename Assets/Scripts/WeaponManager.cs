using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Weapon Settings")] public List<Weapon> weapons;
    public int maxWeaponCount;

    [Header("Current Weapon")] public Weapon currentWeapon;
    private int currentWeaponIndex;

    [Header("Weapon Positioning")] public Transform hand;
    public LayerMask layerMask;

    [HideInInspector] public static WeaponData CurrentGunData;

    private void Start()
    {
        EquipWeapon(currentWeaponIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchWeapon(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchWeapon(1);

        if (Input.GetKeyDown(KeyCode.E)) PickUpWeapon();
    }

    private void SwitchWeapon(int index)
    {
        if (index >= 0 && index < maxWeaponCount && index != currentWeaponIndex && index < weapons.Count)
            EquipWeapon(index);
    }

    private void EquipWeapon(int index)
    {
        if (currentWeapon != null) UnequipWeapon(currentWeapon);

        currentWeaponIndex = index;
        weapons[index].gameObject.SetActive(true);

        CurrentGunData = weapons[index].weaponData;
        CurrentGunData.currentAmmo = CurrentGunData.maxAmmo;

        currentWeapon = weapons[index];
    }

    private void UnequipWeapon(Weapon oldWeapon)
    {
        oldWeapon.gameObject.SetActive(false);
    }

    private void PickUpWeapon()
    {
        Collider[] hits = Physics.OverlapSphere(hand.transform.position, 3f, layerMask);

        if (hits.Length > 0)
        {
            WeaponPickup weaponPickup = hits[0].GetComponent<WeaponPickup>();

            if (weaponPickup != null)
            {
                Weapon newWeapon = weaponPickup.weapon;

                if (weapons.Contains(newWeapon))
                {
                    SwitchWeapon(weapons.IndexOf(newWeapon));
                }
                else
                {
                    if (weapons.Count < maxWeaponCount)
                    {
                        AddWeapon(newWeapon);
                        newWeapon.gameObject.SetActive(false);
                        PreparingWeaponToUse(newWeapon);
                    }
                    else
                    {
                        weapons[currentWeaponIndex] = newWeapon;
                        PreparingWeaponToUse(newWeapon);
                        EquipWeapon(currentWeaponIndex);
                    }
                }
            }
        }
    }

    public void PreparingWeaponToUse(Weapon weapon)
    {
        weapon.transform.parent = hand.transform;
        weapon.transform.position = hand.position;
    }

    public void AddWeapon(Weapon newWeapon)
    {
        weapons.Add(newWeapon);
    }
}