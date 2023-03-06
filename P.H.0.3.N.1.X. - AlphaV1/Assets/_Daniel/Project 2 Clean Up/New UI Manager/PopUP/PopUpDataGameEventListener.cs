using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PopUpDataGameEventListener : MonoBehaviour
{
    public PopUpDataGameEventScriptableObject gameEvent;
    public UnityEvent<PopUpDataScriptableObject> respone;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(PopUpDataScriptableObject popUpData)
    {
        respone.Invoke(popUpData);
    }
}
