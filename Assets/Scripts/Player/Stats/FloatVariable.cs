using Kryz.CharacterStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    // Editor value
    [SerializeField] private float baseValue = 1f;            // Base cooldown
                                                                 // Internal variables
                                                                 // Ability CoolDown
    private float _value;
    public float Value { get { return _value; } }

    // Initialize coolDown with editor's value
    private void OnEnable()
    {
        _value = baseValue;
    }

    // You can also use OnAfterDeserialize for the other way around
    public void OnAfterDeserialize()
    {
    }
}
