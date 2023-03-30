/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 6, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the scriptable object game event class for audio manager audio data events.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioDataGameEvent", menuName = "Scriptable Objects/Game Events/Game Managers/Audio Manager/Audio Data Game Event")]
public class AudioDataGameEventScriptableObject : ScriptableObject
{
    #region Class Variables
    //Game Events Listener
    private List<AudioDataGameEventListener> listeners = new List<AudioDataGameEventListener>();
    #endregion

    #region Registration Listener
    public void RegisterListener(AudioDataGameEventListener a_listener)
    {
        listeners.Add(a_listener);
    }

    public void UnregisterListener(AudioDataGameEventListener a_listener)
    {
        listeners.Remove(a_listener);
    }
    #endregion

    #region Raise/Invoke Game Events
    public void Raise(AudioDataScriptableObject a_audioData)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(a_audioData);
        }
    }
    #endregion
}