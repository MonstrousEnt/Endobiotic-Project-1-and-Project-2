/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 18, 2023
 * Last Updated: Match 30, 2023
 * Description: This is the UI class for timer.
 * Notes: 
 * Resources: 
 *  
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimer : MonoBehaviour
{
    #region Class Variables
    [Header("UI Components")]
    [SerializeField] private TextMeshProUGUI m_timerText;

    [Header("Time Data Scriptable Object")]
    [SerializeField] private TimerDataScriptableObject m_timerData;
    #endregion

    #region Unity Methods
    private void Update()
    {
        if (m_timerData.updateUI && m_timerData.startTimer)
        {
            displayTime(m_timerData.timeInSeconds);
        }
    }

    #endregion

    #region UI Methods
    private void displayTime(float a_timeInSeconds)
    {
        string l_displayTime = "00:00";

        TimeSpan timeSpan = TimeSpan.FromSeconds(a_timeInSeconds);

        l_displayTime = string.Format("{0:00}:{1:00}", (int)timeSpan.Minutes, (int)timeSpan.Seconds);
        m_timerText.text = "Timer: " + l_displayTime;
    }
    #endregion
}