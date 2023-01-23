using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject
{
    public List<T> Items = new List<T>();

    public virtual void Add(T thing)
    {
        if (!Items.Contains(thing))
            Items.Add(thing);
    }

    public virtual void Remove(T thing)
    {
        if (Items.Contains(thing))
            Items.Remove(thing);
    }
}
