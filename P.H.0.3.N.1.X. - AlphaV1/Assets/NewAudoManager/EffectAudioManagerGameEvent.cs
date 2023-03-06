using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAudioManagerGameEvent : MonoBehaviour
{
    #region Class Variables
    [Header("Audio Data")]
    [SerializeField] private AudioDataScriptableObject m_audioData;

    [Header("Game Event Scriptable Objects - Audio Manager")]
    [SerializeField] private AudioDataGameEventScriptableObject m_audioManagerGameEventPlaySound;
    [SerializeField] private AudioDataGameEventScriptableObject m_audioManagerGameEventStopSound;
    [SerializeField] private AudioDataGameEventScriptableObject m_audioManagerGameEventEnableLoop;
    [SerializeField] private AudioDataGameEventScriptableObject m_audioManagerGameEventDisableLoop;
    #endregion

    #region Call Audio Manager Game Event
    public void PlaySound()
    {
        m_audioManagerGameEventPlaySound.Raise(m_audioData);
    }

    public void StopSound()
    {
        m_audioManagerGameEventStopSound.Raise(m_audioData);
    }

    public void EnableLoop()
    {
        m_audioManagerGameEventEnableLoop.Raise(m_audioData);
    }

    public void DisableLoop()
    {
        m_audioManagerGameEventDisableLoop.Raise(m_audioData);
    }
    #endregion
}
