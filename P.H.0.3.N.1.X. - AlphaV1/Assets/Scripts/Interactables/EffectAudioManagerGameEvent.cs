/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 6, 2023
 * Last Updated: April 2, 2023
 * Description: This effect class is for control in game audio of any game object.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAudioManagerGameEvent : MonoBehaviour
{
    #region Class Variables
    [Header("Audio Data")]
    [SerializeField] private AudioDataScriptableObject m_audioData;
    [SerializeField] private AudioListScriptableObject m_audioList;

    [Header("Game Event Scriptable Objects - Audio Manager")]
    [SerializeField] private AudioDataGameEventScriptableObject m_audioManagerGameEventPlaySound;
    [SerializeField] private AudioListGameEventScritableObject m_audioManagerGameEventPlayRandomSound;
    [SerializeField] private AudioDataGameEventScriptableObject m_audioManagerGameEventStopSound;
    [SerializeField] private AudioDataGameEventScriptableObject m_audioManagerGameEventEnableLoop;
    [SerializeField] private AudioDataGameEventScriptableObject m_audioManagerGameEventDisableLoop;
    #endregion

    #region Call Audio Manager Game Events
    public void PlaySound()
    {
        if (m_audioData != null)
        {
            m_audioManagerGameEventPlaySound.Raise(m_audioData);
        }
    }

    public void PlayRandomSound()
    {
        if (m_audioList != null)
        {
            m_audioManagerGameEventPlayRandomSound.Raise(m_audioList);
        }
    }

    public void StopSound()
    {
        if (m_audioData != null)
        {
            m_audioManagerGameEventStopSound.Raise(m_audioData);
        }
    }

    public void EnableLoop()
    {
        if (m_audioData != null)
        {
            m_audioManagerGameEventEnableLoop.Raise(m_audioData);
        }
    }

    public void DisableLoop()
    {
        if (m_audioData != null)
        {
            m_audioManagerGameEventDisableLoop.Raise(m_audioData);
        }
    }
    #endregion
}
