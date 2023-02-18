using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIEvents : MonoBehaviour
{
    [Header("Bool Flag Var Golabl")]
    public bool pauseMneuIsActive = false;

    [Header("Root")]
    public UnityEvent<bool> activeFadeBackgroundUnityEvents;

    [Header("UI Menus")]
    public UnityEvent<bool> activePauseMenuUnityEvent;
    public UnityEvent<bool> activeGameInstructionMenuUnityEvent;

    [Header("Other UI")]
    public UnityEvent<PopUpData> setPopUpDataUnityEvent;
    public UnityEvent<bool> activePopUpUnityEvent;
    public UnityEvent<DialogueData> setDialogueDataUnityEvent;
    public UnityEvent<bool> activeDialogueBoxUnityEvent;
    public UnityEvent displayGameCreditsUnityEvent;

    public void InvokeActiveFadeBackground(bool activeFlag)
    {
        activeFadeBackgroundUnityEvents.Invoke(activeFlag);
    }

    public void InvokeActivePauseMenu(bool activeFlag)
    {
        activePauseMenuUnityEvent.Invoke(activeFlag);
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
