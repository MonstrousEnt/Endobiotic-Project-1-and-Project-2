using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelGanmeManager : MonoBehaviour
{
    [SerializeField] private PointList pointList;
    [SerializeField] private TimerData timerData;
    public UnityEvent <LevelName> loadNextLevelUnityEvent;

    public void Level1Restart()
    {
        //Any thing we want the game to restart

        pointList.Reset();
        timerData.Reset();
    }

    public void InvokeLoadNextLevelUnityEvent(LevelName scene)
    {
        loadNextLevelUnityEvent.Invoke(scene);
    }
}
