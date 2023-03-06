using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpActions : MonoBehaviour
{
    #region Class Variables 
    [Header("Void Game Event - UI Manager")]
    [SerializeField] private VoidGameEventScriptableObject m_voidGameEventUIManagerDisablePopUp;
    #endregion

    #region Pop Up Action Methods - Quit Game
    public void QuitGame()
    {
        m_voidGameEventUIManagerDisablePopUp.Raise();

        Debug.Log("Quiting Game...");
        Application.Quit();
    }
    #endregion
}
