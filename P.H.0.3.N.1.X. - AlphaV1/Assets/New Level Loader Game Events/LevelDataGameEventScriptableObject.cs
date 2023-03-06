using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataGameEvent", menuName = "Game Events/Level Data Game Event")]
public class LevelDataGameEventScriptableObject : ScriptableObject
{
    private List<LevelDataGameEventListener> listeners = new List<LevelDataGameEventListener>();

    public void Raise(LevelDataScriptableObject levelData)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(levelData);
        }
    }

    public void RegisterListener(LevelDataGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(LevelDataGameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
