using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPauseMenu : UIMenuBase
{
    #region Class Variables 
    [Header("Boolean Flag Global Variable Scriptable Object - UI Manager")]
    [SerializeField] private BooleanFlagGlobalScriptableObjectVariable m_booleanFlagGlobalVariableUIManagerPauseMenuIsActive;
    #endregion

    #region UI Base - Over Methods - Pause Menu
    /// <summary>
    /// Enable the menu and set the global scriptable object variable to true for the UI object.
    /// </summary>
    public override void EnableMenu()
    {
        base.EnableMenu();

        m_booleanFlagGlobalVariableUIManagerPauseMenuIsActive.EnableBoolFlag();
    }

    /// <summary>
    /// Disable the menu and set the global scriptable object variable to false for the UI object.
    /// </summary>
    public override void DisableMenu()
    {
        base.DisableMenu();

        m_booleanFlagGlobalVariableUIManagerPauseMenuIsActive.DisableBooleanFlag();
    }
    #endregion

    #region UI Methods
    /// <summary>
    /// Resume the game and disable the menu
    /// </summary>
    public void ResumeGame()
    {
        DisableMenu();
    }

    //public void OpenHowToPlayMenu()
    //{
    //    DisableMenu();
    //    GameMangerRootMaster.instance.uIEvents.InvokeActiveGameInstructionMenu(true);
    //}
    #endregion
}
