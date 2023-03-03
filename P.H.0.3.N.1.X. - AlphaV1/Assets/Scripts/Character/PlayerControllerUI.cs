using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerUI : MonoBehaviour
{
    private void Update()
    {
        //When the user press tab or start button, it open or close the menu.
        if (Input.GetButtonDown("Menu"))
        {
            if (GameMangerRootMaster.instance.uIEvents.pauseMneuIsActive)
            {
                GameMangerRootMaster.instance.uIEvents.InvokeDisablePauseMenu();
            }
            else if (!GameMangerRootMaster.instance.uIEvents.pauseMneuIsActive)
            {
                GameMangerRootMaster.instance.uIEvents.InvokeEnablePauseMenu();
            }
        }
    }
}
