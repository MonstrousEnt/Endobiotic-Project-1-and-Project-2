using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] private PopUpData popUpDataQuitPopUp;

    [SerializeField] private GameObject MainWindowGameObject;

    private void Start()
    {
        GameMangerRootMaster.instance.uIEvents.activePauseMenuUnityEvent.AddListener(activePauseMneu);
    }

    private void activePauseMneu(bool activeFlag)
    {
        GameMangerRootMaster.instance.uIEvents.InvokeActiveFadeBackground(activeFlag);
        MainWindowGameObject.SetActive(activeFlag);

        GameMangerRootMaster.instance.uIEvents.pauseMneuIsActive = activeFlag;
    }

    public void ResumeGame()
    {
        activePauseMneu(false);
    }

    public void OpenHowToPlayMenu()
    {
        activePauseMneu(false);
        GameMangerRootMaster.instance.uIEvents.InvokeActiveGameInstructionMenu(true);
    }

    public void OepnQuitPopUp()
    {
        GameMangerRootMaster.instance.settingsManager.ActivePause(true, 0f);

        GameMangerRootMaster.instance.uIEvents.InvokeSetPopUpData(popUpDataQuitPopUp);

        GameMangerRootMaster.instance.uIEvents.InvokeActivePopUp(true);
    }

    private void OnDestroy()
    {
        GameMangerRootMaster.instance.uIEvents.activePauseMenuUnityEvent.RemoveListener(activePauseMneu);
    }
}
