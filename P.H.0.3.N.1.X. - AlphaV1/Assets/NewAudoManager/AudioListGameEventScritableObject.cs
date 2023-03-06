using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AudioListGameEvent", menuName = "Game Events/Audio List Game Event")]
public class AudioListGameEventScritableObject : ScriptableObject
{
    private List<AudioListGameEventListener> listeners = new List<AudioListGameEventListener>();

    public void Raise(AudioListScriptableObject audioList)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(audioList);
        }
    }

    public void RegisterListener(AudioListGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(AudioListGameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
