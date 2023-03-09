using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerUI : MonoBehaviour
{
    [Header("Boolean Flag Global Variable Scriptable Object - UI Manager")]
    [SerializeField] private BooleanFlagGlobalVariableScriptableObject m_booleanFlagGlobalVariableUIManagerPauseMenuIsActive;

    [Header("Void Game Event Scriptable Object - UI Manager")]
    [SerializeField] private VoidGameEventScriptableObject m_voidGameEventUIManagerEnablePauseMneu;
    [SerializeField] private VoidGameEventScriptableObject m_voidGameEventUIManagerDisablePauseMneu;

    #region Unity Methods
    private void Update()
    {
        //When the user press tab or start button, it open or close the menu.
        if (Input.GetButtonDown("Menu"))
        {
            if (m_booleanFlagGlobalVariableUIManagerPauseMenuIsActive.booleanFlag)
            {
                m_voidGameEventUIManagerDisablePauseMneu.Raise();
            }
            else if (!m_booleanFlagGlobalVariableUIManagerPauseMenuIsActive.booleanFlag)
            {
                m_voidGameEventUIManagerEnablePauseMneu.Raise();
            }
        }
    }
    #endregion
}
