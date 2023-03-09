using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIMenuBase : UIBase
{
    [Header("UI Components")]
    [SerializeField] protected GameObject m_firstButtonGameObject;

    [Header(" Global Variable Scriptable Object - Player Manager")]
    [SerializeField] protected BooleanFlagGlobalVariableScriptableObject m_booleanFlagGlobalVariablePlayerManagerPlayerCanMove;

    [Header(" Game Events Scriptable Object - Settings Manager")]
    [SerializeField] protected VoidGameEventScriptableObject m_voidGameEventSettingsManagerEnablePause;
    [SerializeField] protected VoidGameEventScriptableObject m_voidGameEventSettingsManagerDisablePause;

    [Header("Game Events Scriptable Object - UI Manager - Fade Background")]
    [SerializeField] protected VoidGameEventScriptableObject M_voidGameEventUIManagerEnableFadeBackground;
    [SerializeField] protected VoidGameEventScriptableObject m_voidGameEventUIManagerDisableFadeBackground;

    [Header("Pop Up Data Scriptable Object")]
    [SerializeField] protected PopUpDataScriptableObject m_popUpDataQuitPopUp;

    [Header("Game Events Scriptable Object - UI Manger - Pop Up")]
    [SerializeField] protected PopUpDataGameEventScriptableObject m_popUpDataGameEventUIMangerSetPopUpData;
    [SerializeField] protected VoidGameEventScriptableObject m_voidGameEventUIManagerEanblePopUp;

    #region Getters and Setters
    protected void SetFirstButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(m_firstButtonGameObject);
    }
    #endregion

    #region UI Menu Base - UI Menu Methods 
    /// <summary>
    /// Enable the menu, default functionally 
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
    /// Disable the menu, default functionally 
    /// </summary>
    public virtual void DisableMenu()
    {
        m_voidGameEventSettingsManagerDisablePause.Raise();
        m_booleanFlagGlobalVariablePlayerManagerPlayerCanMove.EnableBoolFlag();
        m_voidGameEventUIManagerDisableFadeBackground.Raise();
        DisableMainWindow();
    }

    /// <summary>
    /// Open the quit pop up and set the data.
    /// </summary>
    public void OepnQuitPopUp()
    {
        m_popUpDataGameEventUIMangerSetPopUpData.Raise(m_popUpDataQuitPopUp);
        m_voidGameEventUIManagerEanblePopUp.Raise();
    }
    #endregion
}
