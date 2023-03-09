using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VoidGameEvent", menuName = "Scriptable Objects/Game Events/Void Game Event")]
public class VoidGameEventScriptableObject : ScriptableObject
{
    private List<VoidGameEventListener> listeners = new List<VoidGameEventListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(VoidGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(VoidGameEventListener listener)
    {
        listeners.Remove(listener);
    }
}