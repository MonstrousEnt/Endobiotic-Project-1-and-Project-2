using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimerData", menuName = "Scriptable Objects/Data Containers/Timer Data")]
public class TimerDataScriptableObject : ScriptableObject
{
    public float timeInseconds;
    public bool startTimer = false;
    public bool updateUI = false;

    #region Start Timer Methods
    /// <summary>
    /// Enable the time and UI.
    /// </summary>
    public void EnableTime()
    {
        startTimer = true;
        updateUI = true;
    }
    #endregion

    #region Reset Data Methods
    /// <summary>
    /// Reset the timer data.
    /// </summary>
    public void Reset()
    {
        timeInseconds = 0.00f;
        startTimer = false;
        updateUI = false;
    }
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        //Reset the timer
        Reset();
    }
    #endregion
}
