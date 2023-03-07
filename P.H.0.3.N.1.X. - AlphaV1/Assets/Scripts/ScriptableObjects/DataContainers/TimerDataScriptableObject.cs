using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimerData", menuName = "Scriptable Objects/Data Containers/Timer Data")]
public class TimerDataScriptableObject : ScriptableObject
{
    public float timeInseconds;
    public bool startTime = false;
    public bool updateUI = false;

    private void OnEnable()
    {
        //Reset the timer
        Reset();
    }

    /// <summary>
    /// Enable the time and UI.
    /// </summary>
    public void EnableTime()
    {
        startTime = true;
        updateUI = true;
    }

    /// <summary>
    /// Reset the timer data.
    /// </summary>
    public void Reset()
    {
        timeInseconds = 0.00f;
        startTime = false;
        updateUI = false;
    }
}