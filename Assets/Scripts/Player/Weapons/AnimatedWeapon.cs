using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedWeapon : Weapon
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public override void Attack(int attackNum)
    {
        if (anim == null)
            return;
        if (slot == WeaponSlot.Primary)
        {
            anim.SetTrigger(primaryAttack + attackNum);
        }
        else if (slot == WeaponSlot.Secondary)
        {
            anim.SetTrigger(secondaryAttack + attackNum);
        }
        
    }
}
