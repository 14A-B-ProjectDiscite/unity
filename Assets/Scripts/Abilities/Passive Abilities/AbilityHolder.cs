using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class AbilityHolder : RuntimeSet<PassiveAbility>
{
    public override void Add(PassiveAbility ability)
    {
        Items.Add(ability);
        ability.Equip();
    }

    public override void Remove(PassiveAbility thing)
    {
        thing.Unequip();
        Items.Remove(thing);
        
    }
}
