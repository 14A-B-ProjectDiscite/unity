using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOVariable<T> : ScriptableObject
{
    [SerializeField] private T baseValue;
    [SerializeField] private T _value;

    public T Value { get { return _value; } set { _value = value; } }



    private void OnEnable()
    {
        _value = baseValue;
    }
}
