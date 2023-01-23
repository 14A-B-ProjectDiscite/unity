using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChoiceEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public ChoiceEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent<List<PassiveAbility>> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(List<PassiveAbility> list)
    {
        Response.Invoke(list);
        Debug.Log(list.Count);
    }
}
