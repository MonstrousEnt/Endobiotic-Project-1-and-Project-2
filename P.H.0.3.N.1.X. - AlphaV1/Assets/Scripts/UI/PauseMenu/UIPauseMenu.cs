using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPauseMenu : UIMenuBase
{
    [SerializeField] private GameObject MainWindowGameObject;

    private void Start()
    {
        GameMangerRootMaster.instance.uIEvents.enablePauseMenuUnityEvent.AddListener(EnableMenu);
        GameMangerRootMaster.instance.uIEvents.disablePauseMenuUnityEvent.AddListener(DisableMenu);
    }

    private void OnDestroy()
    {
        GameMangerRootMaster.instance.uIEvents.enablePauseMenuUnityEvent.RemoveListener(EnableMenu);
        GameMangerRootMaster.instance.uIEvents.disablePauseMenuUnityEvent.RemoveListener(DisableMenu);
    }

    protected override void EnableMenu()
    {
        base.EnableMenu();

        GameMangerRootMaster.instance.uIEvents.pauseMneuIsActive = true;
    }

    protected override void DisableMenu()
    {
        base.DisableMenu();

        GameMangerRootMaster.instance.uIEvents.pauseMneuIsActive = false;
    }

    public void ResumeGame()
    {
        DisableMenu();
    }

    public void OpenHowToPlayMenu()
    {
        DisableMenu();
        GameMangerRootMaster.instance.uIEvents.InvokeActiveGameInstructionMenu(true);
    }
}
