using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/TypedEvent")]
public class TypedEvent<T> : ScriptableObject
{
    private readonly List<TypedEventListener<T>> eventListeners =
        new List<TypedEventListener<T>>();

    public void Raise(List<T> list)
    {
        string message = "";
        foreach (var item in list)
        {
            if (item == null)
            {
                message += "null;";
            }
        }
        //Debug.Log("Choice Event: " + list.Count + "\n" + message);
        //Debug.Log("Choice Event list: " + list[0].Name + " " + list[1].Name + " " + list[2].Name);
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised(list);
    }

    public void RegisterListener(TypedEventListener<T> listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(TypedEventListener<T> listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
