/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 6, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the scriptable object game event class for UI manager pop up data events.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PopUpDataGameEvent", menuName = "Scriptable Objects/Game Events/Game Managers/UI Manager/Pop Up Data Game Event")]
public class PopUpDataGameEventScriptableObject : ScriptableObject
{
    #region Class Variables
    //Game Events Listener
    private List<PopUpDataGameEventListener> m_listeners = new List<PopUpDataGameEventListener>();
    #endregion

    #region Registration Listener
    public void RegisterListener(PopUpDataGameEventListener a_listener)
    {
        m_listeners.Add(a_listener);
    }

    public void UnregisterListener(PopUpDataGameEventListener a_listener)
    {
        m_listeners.Remove(a_listener);
    }
    #endregion

    #region Raise/Invoke Game Events
    public void Raise(PopUpDataScriptableObject a_popUpData)
    {
        for (int i = m_listeners.Count - 1; i >= 0; i--)
        {
            m_listeners[i].OnEventRaised(a_popUpData);
        }
    }
    #endregion
}
