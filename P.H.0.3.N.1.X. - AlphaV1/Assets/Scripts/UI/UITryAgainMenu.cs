using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UITryAgainMenu : UIMenuBase
{
    [SerializeField] private UIPiontSystem piontSystem;
    [SerializeField] private LevelDataScriptableObject m_levelDataLevel01;

    private void Start()
    {
        GameMangerRootMaster.instance.uIEvents.enableTryAgainMneuUnityEvent.AddListener(EnableMenu);
    }
    private void OnDestroy()
    {
        GameMangerRootMaster.instance.uIEvents.enableTryAgainMneuUnityEvent.RemoveListener(EnableMenu);
    }

    protected override void EnableMenu()
    {
        base.EnableMenu();

        GameMangerRootMaster.instance.uIEvents.tryAgainIsActive = true;

        piontSystem.DisplayPoints();
    }

    protected override void DisableMenu()
    {
        base.DisableMenu();

        GameMangerRootMaster.instance.uIEvents.tryAgainIsActive = false;
    }

    public void TryAgin()
    {
        DisableMenu();

        GameMangerRootMaster.instance.settingsManager.ActivePause(false, 1f);

        GameMangerRootMaster.instance.levelManager.Level1Restart();

        GameMangerRootMaster.instance.levelManager.InvokeLoadNextLevelUnityEvent(m_levelDataLevel01.buildindex);
    }
}
