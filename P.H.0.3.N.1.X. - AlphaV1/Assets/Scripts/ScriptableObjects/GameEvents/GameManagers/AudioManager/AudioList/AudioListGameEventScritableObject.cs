/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 6, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the scriptable object game event class for audio manager audio list events.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AudioListGameEvent", menuName = "Scriptable Objects/Game Events/Game Managers/Audio Manager/Audio List Game Event")]
public class AudioListGameEventScritableObject : ScriptableObject
{
    #region Class Variables
    private List<AudioListGameEventListener> m_listeners = new List<AudioListGameEventListener>();
    #endregion

    #region Registration Listener
    public void RegisterListener(AudioListGameEventListener a_listener)
    {
        m_listeners.Add(a_listener);
    }

    public void UnregisterListener(AudioListGameEventListener a_listener)
    {
        m_listeners.Remove(a_listener);
    }
    #endregion

    #region Raise/Invoke Game Events
    public void Raise(AudioListScriptableObject a_audioList)
    {
        for (int i = m_listeners.Count - 1; i >= 0; i--)
        {
            m_listeners[i].OnEventRaised(a_audioList);
        }
    }
    #endregion
}
