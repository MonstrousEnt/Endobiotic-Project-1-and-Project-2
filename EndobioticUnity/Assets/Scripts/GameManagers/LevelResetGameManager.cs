/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 13, 2023
 * Last Updated: April 2, 2023
 * Description: This is the game manager class for level Reset.
 * Notes: 
 * Resources: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelResetGameManager : MonoBehaviour
{
    #region Class Variables
    [Header("Data Containers - Scriptable Object")]
    [SerializeField] private PointList m_pointList;
    [SerializeField] private TimerDataScriptableObject m_timerData;
    #endregion

    #region Level Reset Game Events 
    public void RestartLevel()
    {
        //Any thing we want the game to restart

        //Reset the unity scriptable objects data containers
        m_pointList.Reset();
        m_timerData.Reset();
    }
    #endregion
}