/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 29, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the scriptable object game event class for timer manager time data events.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerDataGameEventListener : MonoBehaviour
{
    #region Class Variables 
    [Header("Game Event Scriptable Object")]
    [SerializeField] private TimerDataGameEventScriptableObject m_gameEvent;

    [Header("Unity Event")]
    [SerializeField] private UnityEvent<TimerDataScriptableObject> m_response;
    #endregion

    #region Invoke Unity Events
    public void OnEventRaised(TimerDataScriptableObject a_timerData)
    {
        m_response?.Invoke(a_timerData);
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
