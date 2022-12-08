using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponSlot slot;
    public string primaryAttack;
    public string secondaryAttack;

    public virtual void Attack(int attackNum)
    {

    }
}
public enum WeaponSlot
{
    Primary,
    Secondary
}
public enum WeaponType
{
    light, medium, heavy, ranged
}