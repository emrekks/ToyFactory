using UnityEngine;

public class Weapon : MonoBehaviour
{
    public  WeaponData weaponData;
   
    public static Weapon instance;

    private void Awake()
    {
        instance = this;
    }
}
