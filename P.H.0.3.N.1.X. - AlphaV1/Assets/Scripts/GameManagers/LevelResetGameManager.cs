using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelResetGameManager : MonoBehaviour
{
    [SerializeField] private PointList m_pointList;
    [SerializeField] private TimerDataScriptableObject m_timerData;

    public void RestartLevel()
    {
        //Any thing we want the game to restart

        //Reset the unity scriptable objects data containers
        m_pointList.Reset();
        m_timerData.Reset();
    }
}
