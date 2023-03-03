using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPauseMenu : UIMenuBase
{
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

    /// <summary>
    /// Enable the menu and set the global scriptable object variable to true for the UI object.
    /// </summary>
    protected override void EnableMenu()
    {
        base.EnableMenu();

        GameMangerRootMaster.instance.uIEvents.pauseMneuIsActive = true;
    }

    /// <summary>
    /// Disable the menu and set the global scriptable object variable to false for the UI object.
    /// </summary>
    protected override void DisableMenu()
    {
        base.DisableMenu();

        GameMangerRootMaster.instance.uIEvents.pauseMneuIsActive = false;
    }

    /// <summary>
    /// Resume the game and disable the menu
    /// </summary>
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
