/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 5, 2023
 * Last Updated: Match 12, 2023
 * Description: This is the scriptable object game event class for level loader manager level data events.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataGameEvent", menuName = "Scriptable Objects/Game Events/Game Managers/Level Loader Manager/Level Data Game Event")]
public class LevelDataGameEventScriptableObject : ScriptableObject
{
    #region Class Variables
    //Game Events Listener
    private List<LevelDataGameEventListener> listeners = new List<LevelDataGameEventListener>();
    #endregion

    #region Registration Listener
    public void RegisterListener(LevelDataGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(LevelDataGameEventListener listener)
    {
        listeners.Remove(listener);
    }
    #endregion

    #region Raise/Invoke Game Events
    public void Raise(LevelDataScriptableObject levelData)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(levelData);
        }
    }
    #endregion
}
