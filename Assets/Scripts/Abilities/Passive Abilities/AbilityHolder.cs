using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Abilities/AbilityHolder")]
public class AbilityHolder : RuntimeSet<PassiveAbility>
{
    public override void Add(PassiveAbility ability)
    {
        Items.Add(ability);
        ability.Equip();
    }

    public override void Remove(PassiveAbility ability)
    {
        ability.Unequip();
        Items.Remove(ability);
        
    }

    private void OnEnable()
    {
        ClearList();
    }

    public void ClearList()
    {
        //remove all items from the list
        int index = Items.Count - 1;
        while (index >= 0)
        {
            Remove(Items[index]);
            index--;
        }
    }
}
