using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [Header("Boolean Flag Global Variables")]
    public bool pauseMneuIsActive = false;

    [Header("UI Menus")]
    public UnityEvent enablePauseMenuUnityEvent;
    public UnityEvent disablePauseMenuUnityEvent;
    public UnityEvent enableTryAgainMneuUnityEvent;

    public UnityEvent<bool> activeGameInstructionMenuUnityEvent;

    [Header("Other UI")]
    public UnityEvent enableFadeBackgroundUnityEvent;
    public UnityEvent disableFadeBackgroundUnityEvent;
    public UnityEvent<PopUpData> setPopUpDataUnityEvent;
    public UnityEvent enablePopUpUnityEvent;
    public UnityEvent disablePopUpUnityEvent;

    public UnityEvent<DialogueData> setDialogueDataUnityEvent;
    public UnityEvent<bool> activeDialogueBoxUnityEvent;
    public UnityEvent displayGameCreditsUnityEvent;

    public void InvokeEnablePauseMenu() { enablePauseMenuUnityEvent.Invoke(); }
    public void InvokeDisablePauseMenu() { disablePauseMenuUnityEvent.Invoke(); }
    public void InvokeEnableTryAgainMneu() { enableTryAgainMneuUnityEvent.Invoke(); }
    public void InvokeEnableFadeBackground() { enableFadeBackgroundUnityEvent.Invoke(); }
    public void InvokeDisableFadeBackground() { disableFadeBackgroundUnityEvent.Invoke(); }
    public void InvokeEnablePopUp() { enablePopUpUnityEvent.Invoke(); }
    public void InvokeDisablePopUp() { disablePopUpUnityEvent.Invoke(); }


    public void InvokeActiveGameInstructionMenu(bool activeFlag)
    {
        activeGameInstructionMenuUnityEvent.Invoke(activeFlag);
    }

    public void InvokeSetPopUpData(PopUpData popUpData)
    {
        setPopUpDataUnityEvent.Invoke(popUpData);
    }

    public void InvokeSetDialogueDataUnityEvent(DialogueData dialogueData)
    {
        setDialogueDataUnityEvent.Invoke(dialogueData);
    }

    public void InvokeActiveDialogueBoxUnityEvent(bool activeFlag)
    {
        activeDialogueBoxUnityEvent.Invoke(activeFlag);
    }

    public void InvokeDisplayGameCreditsUnityEvent()
    {
        displayGameCreditsUnityEvent.Invoke();
    }
}
