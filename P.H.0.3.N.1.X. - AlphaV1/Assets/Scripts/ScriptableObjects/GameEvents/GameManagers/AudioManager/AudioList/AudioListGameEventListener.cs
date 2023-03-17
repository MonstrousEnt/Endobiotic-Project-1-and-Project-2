/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 5, 2023
 * Last Updated: Match 12, 2023
 * Description: This is the game event listener class for audio manager audio list events.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioListGameEventListener : MonoBehaviour
{
    #region Class Variables 
    [Header("Game Event Scriptable Object")]
    [SerializeField] private AudioListGameEventScritableObject m_gameEvent;

    [Header("Unity Event")]
    [SerializeField] private UnityEvent<AudioListScriptableObject> m_respone;
    #endregion

    #region Invoke Unity Events
    public void OnEventRaised(AudioListScriptableObject audioList)
    {
        m_respone?.Invoke(audioList);
    }
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        m_gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        m_gameEvent.UnregisterListener(this);
    }
    #endregion
}
