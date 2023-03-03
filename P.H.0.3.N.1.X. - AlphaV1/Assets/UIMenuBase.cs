using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMenuBase : UIBase
{
    [Header("UI Menu Data")]
    [SerializeField] protected GameObject m_firstButtonGameObject;
    [SerializeField] protected PopUpData m_popUpDataQuitPopUp;

    /// <summary>
    /// Pause the game. The enable the fade background. Afterwards set the first button for keyboard controls and controller controls. Finally enable the menu.
    /// </summary>
    protected virtual void EnableMenu()
    {
        GameMangerRootMaster.instance.settingsManager.ActivePause(true, 0f);

        GameMangerRootMaster.instance.uIEvents.InvokeEnableFadeBackground();

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(m_firstButtonGameObject);

        EnableMainWindow();
    }

    /// <summary>
    /// Un-pause the game. Then disable the fade background. Finally disable the menu.
    /// </summary>
    protected virtual void DisableMenu()
    {
        GameMangerRootMaster.instance.settingsManager.ActivePause(false, 1f);

        GameMangerRootMaster.instance.uIEvents.InvokeDisableFadeBackground();

        DisableMainWindow();
    }

    /// <summary>
    /// Open the quit pop up and set the data for this pop up.
    /// </summary>
    public void OepnQuitPopUp()
    {
        GameMangerRootMaster.instance.uIEvents.InvokeSetPopUpData(m_popUpDataQuitPopUp);

        GameMangerRootMaster.instance.uIEvents.InvokeEnablePopUp();
    }
}
