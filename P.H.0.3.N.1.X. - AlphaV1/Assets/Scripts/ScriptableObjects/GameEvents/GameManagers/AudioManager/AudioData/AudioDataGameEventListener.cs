using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioDataGameEventListener : MonoBehaviour
{
    [SerializeField] private AudioDataGameEventScriptableObject m_gameEvent;
    [SerializeField] private UnityEvent<AudioDataScriptableObject> m_respone;

    private void OnEnable()
    {
        m_gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        m_gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(AudioDataScriptableObject audioData)
    {
        m_respone.Invoke(audioData);
    }
}
