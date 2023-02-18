using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimer : MonoBehaviour
{
    [SerializeField] private TimerData timerData;

    [SerializeField] private TextMeshProUGUI timerText;

    void Update()
    {
        if (timerData.startTime)
        {
            timerData.timeInseconds += Time.deltaTime;
        }

        if (timerData.UpdateUI && timerData.startTime)
        {
            DisplayTime(timerData.timeInseconds);
        }
    }

    void DisplayTime(float timeValue)
    {
        string displayTime = "00:00";

        TimeSpan timeSpan = TimeSpan.FromSeconds(timeValue);

        displayTime = string.Format("{0:00}:{1:00}", (int)timeSpan.Minutes, (int)timeSpan.Seconds);
        timerText.text = "Timer: " + displayTime;
    }
}
