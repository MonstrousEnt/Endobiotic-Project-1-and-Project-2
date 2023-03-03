using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMenuBase : UIBase
{
    [SerializeField] protected GameObject m_firstButtonGameObject;
    [SerializeField] protected PopUpData m_popUpDataQuitPopUp;

    protected virtual void EnableMenu()
    {
        GameMangerRootMaster.instance.settingsManager.ActivePause(true, 0f);

        GameMangerRootMaster.instance.uIEvents.InvokeEnableFadeBackground();

        EnableMainWindow();

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(m_firstButtonGameObject);
    }
    protected virtual void DisableMenu()
    {
        GameMangerRootMaster.instance.settingsManager.ActivePause(false, 1f);

        GameMangerRootMaster.instance.uIEvents.InvokeDisableFadeBackground();

        DisableMainWindow();
    }

    public void OepnQuitPopUp()
    {
        GameMangerRootMaster.instance.settingsManager.ActivePause(true, 0f);

        GameMangerRootMaster.instance.uIEvents.InvokeSetPopUpData(m_popUpDataQuitPopUp);

        GameMangerRootMaster.instance.uIEvents.InvokeEnablePopUp();
    }
}
