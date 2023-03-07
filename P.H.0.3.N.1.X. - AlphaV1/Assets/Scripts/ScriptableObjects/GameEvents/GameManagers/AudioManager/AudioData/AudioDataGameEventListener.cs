using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioDataGameEventListener : MonoBehaviour
{
    public AudioDataGameEventScriptableObject gameEvent;
    public UnityEvent<AudioDataScriptableObject> respone;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(AudioDataScriptableObject audioData)
    {
        respone.Invoke(audioData);
    }
}
