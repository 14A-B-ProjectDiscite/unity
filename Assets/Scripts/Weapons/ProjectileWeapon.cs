using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform spawnTransform;
    private void Start()
    {
    }
    public override void Attack(int attackNum)
    {
        if (slot == WeaponSlot.Primary)
        {
            
        }
        else if (slot == WeaponSlot.Secondary)
        {
            
        }
        
    }
    void Shoot()
    {
        GameObject go = Instantiate(projectile, spawnTransform.position, spawnTransform.rotation);
    }
}
