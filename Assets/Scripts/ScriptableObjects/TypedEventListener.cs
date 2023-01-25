using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TypedEventListener<T> : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public TypedEvent<T> Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent<List<T>> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(List<T> list)
    {
        Response.Invoke(list);
        Debug.Log(list.Count);
    }
}
