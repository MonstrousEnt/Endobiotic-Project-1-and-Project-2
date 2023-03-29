using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    #region Class Variables
    [Header("Time Data")]
    [SerializeField] private TimerDataScriptableObject m_timerData;
    #endregion

    #region Timer Game Events
    public void SetUpTimer(TimerDataScriptableObject timerData)
    {
        timerData.Reset();

        m_timerData = null;

        this.m_timerData = timerData;
    }

    public void EnableTime(TimerDataScriptableObject timerData)
    {
        timerData.startTimer = true;
        timerData.updateUI = true;
    }
    #endregion

    #region Time Mode Methods
    private void UpdataeTimer(TimerDataScriptableObject timerData)
    {
        switch (timerData.timerMode)
        {
            case TimerMode.CountUp:
            {
                countUpTimer(timerData);
                break;
            }
            case TimerMode.CountDown:
            {
                countDownTimer(timerData);
                break;
            }
        }
    }

    private void countUpTimer(TimerDataScriptableObject timerData)
    {
        timerData.timeInseconds += Time.deltaTime;
    }

    private void countDownTimer(TimerDataScriptableObject timerData)
    {
        timerData.timeInseconds -= Time.deltaTime;
    }
    #endregion

    #region Unity Methods
    private void Update()
    {
        if (m_timerData != null)
        {
            if (m_timerData.startTimer)
            {
                UpdataeTimer(m_timerData);
            }
        }
    }
    #endregion
}
