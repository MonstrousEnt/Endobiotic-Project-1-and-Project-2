using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimerDataGameEvent", menuName = "Scriptable Objects/Game Events/Game Managers/Timer Manager/Timer Data Game Event")]
public class TimerDataGameEventScriptableObject : ScriptableObject
{
    #region Class Variables
    //Game Events Listener
    private List<TimerDataGameEventListener> listeners = new List<TimerDataGameEventListener>();
    #endregion

    #region Registration Listener
    public void RegisterListener(TimerDataGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(TimerDataGameEventListener listener)
    {
        listeners.Remove(listener);
    }
    #endregion

    #region Raise/Invoke Game Events
    public void Raise(TimerDataScriptableObject timerData)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(timerData);
        }
    }
    #endregion
}
