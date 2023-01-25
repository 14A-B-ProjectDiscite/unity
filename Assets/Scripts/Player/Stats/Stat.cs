using Kryz.CharacterStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Stat : ScriptableObject
{
    // Editor value
    [SerializeField] private float baseValue = 1f;            // Base cooldown
                                                              // Internal variables
    [SerializeField]                                                             // Ability CoolDown
    private CharacterStat stat;
    public CharacterStat Statistic { get { return stat; } }

    // Initialize coolDown with editor's value
    private void OnEnable()
    {
        stat = new CharacterStat(baseValue);
    }

    // You can also use OnAfterDeserialize for the other way around
    public void OnAfterDeserialize()
    {
    }
}
