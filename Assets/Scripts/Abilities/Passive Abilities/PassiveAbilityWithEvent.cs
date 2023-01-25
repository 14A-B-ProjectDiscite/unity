using Kryz.CharacterStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PassiveAbilityWithEvent : PassiveAbility
{
    [SerializeField]
    GameEvent gameEvent;
    public override void Equip()
    {
        base.Equip();
        gameEvent.Raise();
    }

    public override void Unequip()
    {
        base.Unequip();
        gameEvent.Raise();

    }
}
