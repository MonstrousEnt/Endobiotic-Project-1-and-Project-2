using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UITryAgainMenu : UIMenuBase
{
    [Header("Point System")]
    [SerializeField] private UIPiontSystem m_piontSystem;

    [Header("Unity Event")]
    [SerializeField] private UnityEvent m_tryAgainunityEvent;

    #region UI Base - Over Methods - Try Again Menu
    /// <summary>
    /// Enable the menu and display the points,
    /// </summary>
    public override void EnableMenu()
    {
        base.EnableMenu();

        m_piontSystem.DisplayPoints();
    }
    #endregion

    #region UI Methods
    /// <summary>
    /// Disable the menu and reset the level.
    /// </summary>
    public void TryAgin()
    {
        DisableMenu();

        m_tryAgainunityEvent.Invoke();
    }
    #endregion
}
