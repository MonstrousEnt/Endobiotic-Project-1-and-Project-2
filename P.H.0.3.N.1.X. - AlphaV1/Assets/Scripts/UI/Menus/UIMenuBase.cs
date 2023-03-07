using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIMenuBase : UIBase
{
    #region Class Variables
    [Header("UI Menu Base Data - UI Components")]
    [SerializeField] protected GameObject m_firstButtonGameObject;

    [Header("UI Menu Base Data - Global Variable Scriptable Object - Player Manager")]
    [SerializeField] protected BooleanFlagGlobalVariableScriptableObject m_booleanFlagGlobalVariablePlayerManagerPlayerCanMove;

    [Header("UI Menu Base Data - Game Events Scriptable Object - Settings Manager")]
    [SerializeField] protected VoidGameEventScriptableObject m_voidGameEventSettingsManagerEnablePause;
    [SerializeField] protected VoidGameEventScriptableObject m_voidGameEventSettingsManagerDisablePause;

    [Header("UI Menu Base Data -Game Events Scriptable Object - UI Manager - Fade Background")]
    [SerializeField] protected VoidGameEventScriptableObject M_voidGameEventUIManagerEnableFadeBackground;
    [SerializeField] protected VoidGameEventScriptableObject m_voidGameEventUIManagerDisableFadeBackground;

    [Header("UI Menu Base Data- Pop Up Data Scriptable Object")]
    [SerializeField] protected PopUpDataScriptableObject m_popUpDataQuitPopUp;

    [Header("UI Menu Base Data - Game Events Scriptable Object - UI Manger - Pop Up")]
    [SerializeField] protected PopUpDataGameEventScriptableObject m_popUpDataGameEventUIMangerSetPopUpData;
    [SerializeField] protected VoidGameEventScriptableObject m_voidGameEventUIManagerEanblePopUp;
    #endregion

    #region Getters and Setters
    protected void SetFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(m_firstButtonGameObject);
    }
    #endregion

    #region UI Menu Base - UI Menu Methods 
    /// <summary>
    /// Pause the game. 
    /// Then disable Player Can Move.
    /// Next, enable the fade background. 
    /// Afterwards set the first button for keyboard controls and controller controls. 
    /// Finally enable the menu.
    /// </summary>
    public virtual void EnableMenu()
    {
        m_voidGameEventSettingsManagerEnablePause.Raise();
        m_booleanFlagGlobalVariablePlayerManagerPlayerCanMove.DisableBooleanFlag();
        M_voidGameEventUIManagerEnableFadeBackground.Raise();
        SetFirstButton();
        EnableMainWindow();
    }

    /// <summary>
    /// Un-pause the game. 
    /// Then enable Player Can Move.
    /// Next, disbale the fade background. 
    /// Finally disable the menu.
    /// </summary>
    public virtual void DisableMenu()
    {
        m_voidGameEventSettingsManagerDisablePause.Raise();
        m_booleanFlagGlobalVariablePlayerManagerPlayerCanMove.EnableBoolFlag();
        m_voidGameEventUIManagerDisableFadeBackground.Raise();
        DisableMainWindow();
    }

    /// <summary>
    /// Open the quit pop up and set the data for this pop up.
    /// </summary>
    public void OepnQuitPopUp()
    {
        m_popUpDataGameEventUIMangerSetPopUpData.Raise(m_popUpDataQuitPopUp);
        m_voidGameEventUIManagerEanblePopUp.Raise();
    }
    #endregion
}
