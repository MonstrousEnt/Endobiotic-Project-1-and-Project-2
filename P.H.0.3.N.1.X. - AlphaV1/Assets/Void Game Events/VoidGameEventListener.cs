using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoidGameEventListener : MonoBehaviour
{
    public VoidGameEventScriptableObject gameEvent;
    public UnityEvent respone;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        respone.Invoke();
    }
}
