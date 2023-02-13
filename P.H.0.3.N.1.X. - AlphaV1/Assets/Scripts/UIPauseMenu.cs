using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainWindowGameObject;

    private void Awake()
    {
        GameMangerRootMaster.instance.uIEvents.activePauseMenuUnityEvents.AddListener(activePauseMneu);
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
        GameMangerRootMaster.instance.uIEvents.InvokeActiveHowToPlayMenu(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }

    private void OnDestroy()
    {
        GameMangerRootMaster.instance.uIEvents.activePauseMenuUnityEvents.RemoveListener(activePauseMneu);
    }
}
