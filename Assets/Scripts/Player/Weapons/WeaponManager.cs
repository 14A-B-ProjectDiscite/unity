using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    Weapon primaryWeapon;
    Weapon secondaryWeapon;
    int attackNumber = 0;
    void Update()
    {
        if (primaryWeapon == null)
            return;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attackNumber++;
            primaryWeapon.Attack(attackNumber);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            attackNumber++;
            secondaryWeapon.Attack(attackNumber);
        }
    }

}
