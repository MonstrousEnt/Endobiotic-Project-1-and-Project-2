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
        //When the time start, set it to a count up timer.
        if (m_timerData.startTimer)
        {
           countUpTimer(m_timerData);
        }

        //Update the UI Timer every frame if the timer has started.
        if (m_timerData.updateUI && m_timerData.startTimer)
        {
            displayTime(m_timerData.timeInseconds);
        }
    }
    #endregion

    #region Timer Logic Methods
    /// <summary>
    /// Set the time to count up.
    /// </summary>
    /// <param name="timerData"></param>
    private void countUpTimer(TimerDataScriptableObject timerData) 
    {
        timerData.timeInseconds += Time.deltaTime;
    }

    /// <summary>
    /// Set the time to count down.
    /// </summary>
    /// <param name="timerData"></param>
    private void countDownTimer(TimerDataScriptableObject timerData)
    {
        timerData.timeInseconds -= Time.deltaTime;
    }
    #endregion

    #region UI Methods
    /// <summary>
    /// Display the time in a minutes format.
    /// </summary>
    /// <param name="timeInSeconds"></param>
    private void displayTime(float timeInSeconds)
    {
        string displayTime = "00:00";

        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);

        displayTime = string.Format("{0:00}:{1:00}", (int)timeSpan.Minutes, (int)timeSpan.Seconds);
        m_timerText.text = "Timer: " + displayTime;
    }
    #endregion
}