using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoidEventListener : MonoBehaviour
{
    [SerializeField] private voidEvent _event = default;

    public UnityEvent listener;

    private void onEnable()
    {
        _event?.Subscribe(Respond);
    }

    private void onDisable()
    {
        _event?.Unsubscribe(Respond);
    }

    private void Respond()
    {
        listener?.Invoke();
    }

}