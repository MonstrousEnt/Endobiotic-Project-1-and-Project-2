using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIEvents : MonoBehaviour
{
    [Header("Bool Flag Var Golabl")]
    public bool pauseMneuIsActive = false;
    public bool tryAgainIsActive = false;

    [Header("Root")]
    public UnityEvent<bool> activeFadeBackgroundUnityEvents;

    [Header("UI Menus")]
    public UnityEvent enablePauseMenuUnityEvent;
    public UnityEvent disablePauseMenuUnityEvent;
    public UnityEvent enableTryAgainMneuUnityEvent;

    public UnityEvent<bool> activeGameInstructionMenuUnityEvent;


    [Header("Other UI")]
    public UnityEvent<PopUpData> setPopUpDataUnityEvent;
    public UnityEvent<bool> activePopUpUnityEvent;
    public UnityEvent<DialogueData> setDialogueDataUnityEvent;
    public UnityEvent<bool> activeDialogueBoxUnityEvent;
    public UnityEvent displayGameCreditsUnityEvent;


    public void InvokeEnablePauseMenu() { enablePauseMenuUnityEvent.Invoke(); }
    public void InvokeDisablePauseMenu() { disablePauseMenuUnityEvent.Invoke(); }
    public void InvokeEnableTryAgainMneu() { enableTryAgainMneuUnityEvent.Invoke(); }


    public void InvokeActiveFadeBackground(bool activeFlag)
    {
        activeFadeBackgroundUnityEvents.Invoke(activeFlag);
    }

    public void InvokeActiveGameInstructionMenu(bool activeFlag)
    {
        activeGameInstructionMenuUnityEvent.Invoke(activeFlag);
    }

    public void InvokeSetPopUpData(PopUpData popUpData)
    {
        setPopUpDataUnityEvent.Invoke(popUpData);
    }

    public void InvokeActivePopUp(bool activeFlag)
    {
        activePopUpUnityEvent.Invoke(activeFlag);
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
