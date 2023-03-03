using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFadeBackground : UIBase
{
    private void Start()
    {
        GameMangerRootMaster.instance.uIEvents.enableFadeBackgroundUnityEvent.AddListener(EnableMainWindow);
        GameMangerRootMaster.instance.uIEvents.disableFadeBackgroundUnityEvent.AddListener(DisableMainWindow);
    }
    private void OnDestroy()
    {
        GameMangerRootMaster.instance.uIEvents.enableFadeBackgroundUnityEvent.AddListener(EnableMainWindow);
        GameMangerRootMaster.instance.uIEvents.disableFadeBackgroundUnityEvent.AddListener(DisableMainWindow);
    }
}
