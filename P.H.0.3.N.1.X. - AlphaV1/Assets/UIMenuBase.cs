using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMenuBase : MonoBehaviour
{
    [SerializeField] protected GameObject m_mainWindowGameObject;
    [SerializeField] protected GameObject m_firstButtonGameObject;
    [SerializeField] protected PopUpData m_popUpDataQuitPopUp;

    private void enableMainWindow()
    {
        m_mainWindowGameObject.SetActive(true);
    }

    private void disableMainWindow()
    {
        m_mainWindowGameObject.SetActive(false);
    }

    protected virtual void EnableMenu()
    {
        GameMangerRootMaster.instance.settingsManager.ActivePause(true, 0f);

        GameMangerRootMaster.instance.uIEvents.InvokeEnableFadeBackground();

        enableMainWindow();

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(m_firstButtonGameObject);
    }
    protected virtual void DisableMenu()
    {
        GameMangerRootMaster.instance.settingsManager.ActivePause(false, 1f);

        GameMangerRootMaster.instance.uIEvents.InvokeDisableFadeBackground();

        disableMainWindow();
    }

    public void OepnQuitPopUp()
    {
        GameMangerRootMaster.instance.settingsManager.ActivePause(true, 0f);

        GameMangerRootMaster.instance.uIEvents.InvokeSetPopUpData(m_popUpDataQuitPopUp);

        GameMangerRootMaster.instance.uIEvents.InvokeActivePopUp(true);
    }
}
