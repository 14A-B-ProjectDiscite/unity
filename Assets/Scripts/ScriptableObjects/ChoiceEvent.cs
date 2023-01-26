using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/ChoiceEvent")]
public class ChoiceEvent : ScriptableObject
{
    private readonly List<ChoiceEventListener> eventListeners =
        new List<ChoiceEventListener>();

    public void Raise(List<PassiveAbility> list)
    {
        string message = "";
        foreach (var item in list)
        {
            if (item == null)
            {
                message += "null;";
            }
        }
        Debug.Log("Choice Event: " + list.Count + "\n" + message);
        //Debug.Log("Choice Event list: " + list[0].Name + " " + list[1].Name + " " + list[2].Name);
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised(list);
    }

    public void RegisterListener(ChoiceEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(ChoiceEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
