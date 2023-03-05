using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioDataGameEvent", menuName = "Game Events/Audio Data Game Event")]
public class AudioDataGameEventScriptableObject : ScriptableObject
{
    private List<AudioDataGameEventListener> listeners = new List<AudioDataGameEventListener>();

    public void Raise(AudioDataScriptableObject audioData)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(audioData);
        }
    }

    public void RegisterListener(AudioDataGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(AudioDataGameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
