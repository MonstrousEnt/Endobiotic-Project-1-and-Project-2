using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioListGameEventListener : MonoBehaviour
{
    public AudioListGameEventScritableObject gameEvent;
    public UnityEvent<AudioListScriptableObject> respone;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(AudioListScriptableObject audioList)
    {
        respone.Invoke(audioList);
    }
}
