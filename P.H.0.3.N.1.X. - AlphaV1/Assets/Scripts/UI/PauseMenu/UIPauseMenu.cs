using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] private PopUpData popUpDataQuitPopUp;

    [SerializeField] private GameObject MainWindowGameObject;

    [SerializeField] private GameObject pauseFirstButton;

    private void Start()
    {
        GameMangerRootMaster.instance.uIEvents.activePauseMenuUnityEvent.AddListener(activePauseMneu);
    }

    private void activePauseMneu(bool activeFlag)
    {
        GameMangerRootMaster.instance.uIEvents.InvokeActiveFadeBackground(activeFlag);
        MainWindowGameObject.SetActive(activeFlag);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);

        //set a new selected object
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);

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
