using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatWithEvent : CharacterStat
{
    private GameEvent ge;
    public CharacterStatWithEvent(GameEvent gameEvent, float baseValue)
    {
        BaseValue = baseValue;
        ge = gameEvent;
    }
     
    public override void AddModifier(StatModifier mod)
    {
        base.AddModifier(mod);
        ge.Raise();
    }
}
