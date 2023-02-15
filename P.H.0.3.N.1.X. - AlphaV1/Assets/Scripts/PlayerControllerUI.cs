using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerUI : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameMangerRootMaster.instance.uIEvents.pauseMneuIsActive)
            {
                GameMangerRootMaster.instance.settingsManager.ActivePause(false, 1f);
                GameMangerRootMaster.instance.uIEvents.InvokeActivePauseMenu(false);
            }
            else if (!GameMangerRootMaster.instance.uIEvents.pauseMneuIsActive)
            {
                GameMangerRootMaster.instance.settingsManager.ActivePause(true, 0f);
                GameMangerRootMaster.instance.uIEvents.InvokeActivePauseMenu(true);
            }
        }
    }
}
