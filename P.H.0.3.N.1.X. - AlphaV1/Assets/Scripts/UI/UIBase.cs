/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 3, 2023
 * Last Updated: Match 12, 2023
 * Description: This is the UI base class.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    #region Class Variables
    [Header("Main Window Data")]
    [SerializeField] protected GameObject m_mainWindowGameObject;
    #endregion

    #region UI Base - UI Main Window Methods
    /// <summary>
    /// Enable the main window.
    /// </summary>
    public void EnableMainWindow()
    {
        m_mainWindowGameObject.SetActive(true);
    }

    /// <summary>
    /// Disable the main window.
    /// </summary>
    public void DisableMainWindow()
    {
        m_mainWindowGameObject.SetActive(false);
    }
    #endregion
}