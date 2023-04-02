/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 5, 2023
 * Last Updated: April 2, 2023
 * Description: This is the game event listener class for UI manager pop up data events.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PopUpDataGameEventListener : MonoBehaviour
{
    #region Class Variables 
    [Header("Game Event Scriptable Object")]
    [SerializeField] private PopUpDataGameEventScriptableObject m_gameEvent;

    [Header("Unity Event")]
    [SerializeField] private UnityEvent<PopUpDataScriptableObject> m_response;
    #endregion

    #region Invoke Unity Events
    public void OnEventRaised(PopUpDataScriptableObject a_popUpData)
    {
        m_response?.Invoke(a_popUpData);
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
