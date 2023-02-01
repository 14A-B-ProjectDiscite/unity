using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    Weapon primaryWeapon;
    [SerializeField]
    Weapon secondaryWeapon;
    int attackNumber = 0;
    [SerializeField] GameEvent attacked;
    [SerializeField] GameEvent primaryAttacked;
    [SerializeField] GameEvent secondaryAttacked;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && primaryWeapon != null)
        {
            attackNumber++;
            if (primaryWeapon.maxCombo < attackNumber)
            {
                attackNumber = 1;
            }
            primaryWeapon.Attack(attackNumber);
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && secondaryWeapon != null)
        {
            attackNumber++;
            if (primaryWeapon.maxCombo < attackNumber)
            {
                attackNumber = 1;
            }
            secondaryWeapon.Attack(attackNumber);
        }
    }

}
