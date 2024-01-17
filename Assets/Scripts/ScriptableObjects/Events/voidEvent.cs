using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Events/void Event")]
public class voidEvent : ScriptableObjectBase
{
    public UnityAction onEventRaised;

    public void  RaiseEvent()
    {
        onEventRaised?.Invoke();
    }

    public void Subscribe(UnityAction function)
    {
        onEventRaised += function;
    }
    public void Unsubscribe(UnityAction function)
    {
        onEventRaised -= function;
    }











}
