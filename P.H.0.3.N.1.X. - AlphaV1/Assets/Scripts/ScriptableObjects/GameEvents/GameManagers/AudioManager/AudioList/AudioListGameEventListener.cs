using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioListGameEventListener : MonoBehaviour
{
    [SerializeField] private AudioListGameEventScritableObject m_gameEvent;
    [SerializeField] private UnityEvent<AudioListScriptableObject> m_respone;

    private void OnEnable()
    {
        m_gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        m_gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(AudioListScriptableObject audioList)
    {
        m_respone.Invoke(audioList);
    }
}
