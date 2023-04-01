/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 29, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the game event listener class for timer manager timer data events.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimerDataGameEvent", menuName = "Scriptable Objects/Game Events/Game Managers/Timer Manager/Timer Data Game Event")]
public class TimerDataGameEventScriptableObject : ScriptableObject
{
    #region Class Variables
    private List<TimerDataGameEventListener> m_listeners = new List<TimerDataGameEventListener>();
    #endregion

    #region Registration Listener
    public void RegisterListener(TimerDataGameEventListener a_listener)
    {
        m_listeners.Add(a_listener);
    }

    public void UnregisterListener(TimerDataGameEventListener a_listener)
    {
        m_listeners.Remove(a_listener);
    }
    #endregion

    #region Raise/Invoke Game Events
    public void Raise(TimerDataScriptableObject a_timerData)
    {
        for (int i = m_listeners.Count - 1; i >= 0; i--)
        {
            m_listeners[i].OnEventRaised(a_timerData);
        }
    }
    #endregion
}
