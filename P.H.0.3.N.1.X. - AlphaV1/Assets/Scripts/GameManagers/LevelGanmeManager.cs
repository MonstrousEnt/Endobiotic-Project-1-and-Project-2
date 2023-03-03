using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelGanmeManager : MonoBehaviour
{
    [SerializeField] private PointList pointList;
    [SerializeField] private TimerDataScriptableObject timerData;
    public UnityEvent<int> loadNextLevelUnityEvent;

    public void Level1Restart()
    {
        //Any thing we want the game to restart

        pointList.Reset();
        timerData.Reset();
    }

    public void InvokeLoadNextLevelUnityEvent(int buildIndex)
    {
        loadNextLevelUnityEvent.Invoke(buildIndex);
    }
}
