using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class AbilityHolder : RuntimeSet<PassiveAbility>
{
    [SerializeField] PlayerStats stats;
    public override void Add(PassiveAbility thing)
    {
        Items.Add(thing);
        thing.Equip(stats);
    }

    public override void Remove(PassiveAbility thing)
    {
        thing.Unequip(stats);
        Items.Remove(thing);
        
    }
}
