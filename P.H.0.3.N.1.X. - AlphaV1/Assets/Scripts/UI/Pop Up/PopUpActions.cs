using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpActions : MonoBehaviour
{
    [SerializeField] private VoidGameEventScriptableObject m_voidGameEventUIManagerDisablePopUp;

    public void QuitGame()
    {
        m_voidGameEventUIManagerDisablePopUp.Raise();

        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}
