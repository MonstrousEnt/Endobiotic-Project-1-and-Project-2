using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpActions : MonoBehaviour
{
    public void QuitGame()
    {
        GameMangerRootMaster.instance.uIEvents.InvokeActivePopUp(false);

        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}
