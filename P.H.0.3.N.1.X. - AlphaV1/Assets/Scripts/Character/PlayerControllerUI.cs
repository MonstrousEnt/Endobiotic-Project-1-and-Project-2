/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 12, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the class for player controls user interface.
 * Notes:
 * Resources: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControllerUI : MonoBehaviour
{
    #region Class Variables 
    [Header("Boolean Flag Global Variable Scriptable Object - UI Manager")]
    [SerializeField] private BooleanFlagGlobalVariableScriptableObject m_booleanFlagGlobalVariableUIManagerPauseMenuIsActive;

    [Header("Unity Events")]
    [SerializeField] private UnityEvent m_enablePauseMneuUnityEevnt;
    [SerializeField] private UnityEvent m_disablePauseMneuUnityEevnt;
    #endregion

    #region Unity Methods
    private void Update()
    {
        //Player Menu
        if (Input.GetButtonDown("Menu"))
        {
            if (m_booleanFlagGlobalVariableUIManagerPauseMenuIsActive.booleanFlag)
            {
                m_disablePauseMneuUnityEevnt?.Invoke();
            }
            else if (!m_booleanFlagGlobalVariableUIManagerPauseMenuIsActive.booleanFlag)
            {
                m_enablePauseMneuUnityEevnt?.Invoke();
            }
        }
    }
    #endregion
}
