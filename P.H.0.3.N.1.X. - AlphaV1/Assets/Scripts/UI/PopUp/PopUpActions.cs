/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 14, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the UI action class for pop up.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PopUpActions : MonoBehaviour
{
    #region Class Variables
    [Header("Unity Events")]
    [SerializeField] private UnityEvent m_disablePopUpUnityEvent;
    #endregion

    #region Pop Up Action Methods - Quit Game
    public void QuitGame()
    {
        m_disablePopUpUnityEvent?.Invoke();

        Debug.Log("Quiting Game...");
        Application.Quit();
    }
    #endregion
}
