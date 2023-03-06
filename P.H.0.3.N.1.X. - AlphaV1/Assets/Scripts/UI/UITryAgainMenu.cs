using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UITryAgainMenu : UIMenuBase
{
    [SerializeField] private UIPiontSystem m_piontSystem;

    [SerializeField] private UnityEvent m_tryAgainunityEvent;

    private void Start()
    {
        GameMangerRootMaster.instance.uIEvents.enableTryAgainMneuUnityEvent.AddListener(EnableMenu);
    }
    private void OnDestroy()
    {
        GameMangerRootMaster.instance.uIEvents.enableTryAgainMneuUnityEvent.RemoveListener(EnableMenu);
    }

    /// <summary>
    /// Enable the menu and display the points,
    /// </summary>
    protected override void EnableMenu()
    {
        base.EnableMenu();

        m_piontSystem.DisplayPoints();
    }

    /// <summary>
    /// Disable the menu and reset the level.
    /// </summary>
    public void TryAgin()
    {
        DisableMenu();

        m_tryAgainunityEvent.Invoke();
    }
}
