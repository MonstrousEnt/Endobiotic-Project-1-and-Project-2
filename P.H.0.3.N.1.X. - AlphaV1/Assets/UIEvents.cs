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
    public UnityEvent<bool> activePauseMenuUnityEvents;
    public UnityEvent<bool> activeHowToPlayMenuUnityEvents;

    public void InvokeActiveFadeBackground(bool activeFlag)
    {
        activeFadeBackgroundUnityEvents.Invoke(activeFlag);
    }

    public void InvokeActivePauseMenu(bool activeFlag)
    {
        activePauseMenuUnityEvents.Invoke(activeFlag);
    }


    public void InvokeActiveHowToPlayMenu(bool active)
    {
        activeHowToPlayMenuUnityEvents.Invoke(active);
    }
}
