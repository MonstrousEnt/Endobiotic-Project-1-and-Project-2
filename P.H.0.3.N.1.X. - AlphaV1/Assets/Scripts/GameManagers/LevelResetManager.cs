using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelResetManager : MonoBehaviour
{
    [SerializeField] private PointList pointList;
    [SerializeField] private TimerDataScriptableObject timerData;
    public UnityEvent<int> loadNextLevelUnityEvent;

    public void RestartLevel()
    {
        //Any thing we want the game to restart

        //Reset the unity scriptable objects data containers
        pointList.Reset();
        timerData.Reset();
    }

    public void InvokeLoadNextLevelUnityEvent(int buildIndex)
    {
        loadNextLevelUnityEvent.Invoke(buildIndex);
    }
}
