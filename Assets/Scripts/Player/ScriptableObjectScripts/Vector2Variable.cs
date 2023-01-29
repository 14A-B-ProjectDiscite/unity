using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Variables/Vector2")]
public class Vector2Variable : ScriptableObject
{
    // Editor value
    [SerializeField] private Vector2 baseValue;            // Base cooldown
                                                              // Internal variables
                                                              // Ability CoolDown
    private Vector2 _value;
    public Vector2 Value { get { return _value; } set { _value = value; } }

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
