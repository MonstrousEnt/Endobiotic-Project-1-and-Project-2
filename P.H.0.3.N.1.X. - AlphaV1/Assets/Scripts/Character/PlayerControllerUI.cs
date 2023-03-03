using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerUI : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
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
