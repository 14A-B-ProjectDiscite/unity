using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Variables/bool")]
public class BoolVariable : ScriptableObject
{
    // Editor value
    [SerializeField] private bool baseValue = false;            // Base cooldown
                                                              // Internal variables
    [SerializeField]                                                             // Ability CoolDown
    private bool _value;
    public bool Value { get { return _value; } set { _value = value; } }

    // Initialize coolDown with editor's value
    private void OnEnable()
    {
        _value = baseValue;
    }

}
