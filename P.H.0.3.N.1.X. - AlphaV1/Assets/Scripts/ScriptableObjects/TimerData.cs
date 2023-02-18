using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimerData", menuName = "Scriptable Objects/Timer Data")]
public class TimerData : ScriptableObject
{
    public float timeInseconds;
    public bool startTime = false;
    public bool UpdateUI = false;

    public void Reset()
    {
        timeInseconds = 0.00f;
        startTime = false;
        UpdateUI = false;
    }

    private void OnEnable()
    {
        Reset();
    }
}
