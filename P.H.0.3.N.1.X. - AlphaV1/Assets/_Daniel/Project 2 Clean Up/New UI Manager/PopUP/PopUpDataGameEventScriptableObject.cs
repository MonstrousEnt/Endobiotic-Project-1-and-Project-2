using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PopUpDataGameEvent", menuName = "Game Events/Pop Up Data Game Event")]
public class PopUpDataGameEventScriptableObject : ScriptableObject
{
    private List<PopUpDataGameEventListener> listeners = new List<PopUpDataGameEventListener>();

    public void Raise(PopUpData popUpData)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(popUpData);
        }
    }

    public void RegisterListener(PopUpDataGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(PopUpDataGameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
