using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Abilities/PassiveAbility")]
public class PassiveAbility : Ability
{
    [SerializeField] List<Stat> stats;
    [SerializeField] List<float> Flat;
    [SerializeField] List<float> PercentAdd;
    [SerializeField] List<float> PercentMult;

    public virtual void Equip()
    {
        if (stats.Count != Flat.Count || stats.Count != PercentAdd.Count || stats.Count != PercentMult.Count )
        {
            Debug.Log("The ability you are trying to add does not have matching list lenghts");
            return;
        }
        for (int i = 0; i < stats.Count; i++)
        {
            if (Flat[i] != 0)
                stats[i].Statistic.AddModifier(new StatModifier(Flat[i], StatModType.Flat, this));
            if (PercentAdd[i] != 0)
                stats[i].Statistic.AddModifier(new StatModifier(PercentAdd[i], StatModType.PercentAdd, this));
            if (PercentMult[i] != 0)
                stats[i].Statistic.AddModifier(new StatModifier(PercentMult[i], StatModType.PercentMult, this));
        }
    }

    public virtual void Unequip()
    {
        foreach (Stat stat in stats)
        {
            stat.Statistic.RemoveAllModifiersFromSource(this);
        }
        
    }
}
