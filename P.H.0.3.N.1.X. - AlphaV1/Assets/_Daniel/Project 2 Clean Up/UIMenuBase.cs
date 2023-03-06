using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIMenuBase : UIBase
{
    [Header("UI Menu Data")]
    [SerializeField] protected GameObject m_firstButtonGameObject;
    [SerializeField] protected PopUpData m_popUpDataQuitPopUp;

    [SerializeField] protected UnityEvent m_enableMenuUnityEvent;
    [SerializeField] protected UnityEvent m_disableMenuUnityEvent;
    [SerializeField] protected UnityEvent m_openQuitPopUpUnityEvent;

    /// <summary>
    /// Pause the game. The enable the fade background. Afterwards set the first button for keyboard controls and controller controls. Finally enable the menu.
    /// </summary>
    public virtual void EnableMenu()
    {
        m_enableMenuUnityEvent.Invoke();

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(m_firstButtonGameObject);

        EnableMainWindow();
    }

    /// <summary>
    /// Un-pause the game. Then disable the fade background. Finally disable the menu.
    /// </summary>
    public virtual void DisableMenu()
    {
        m_disableMenuUnityEvent.Invoke();

        DisableMainWindow();
    }

    /// <summary>
    /// Open the quit pop up and set the data for this pop up.
    /// </summary>
    public void OepnQuitPopUp()
    {
        m_openQuitPopUpUnityEvent.Invoke();
    }
}
