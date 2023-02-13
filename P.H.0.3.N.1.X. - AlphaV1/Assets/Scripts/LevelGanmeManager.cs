using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGanmeManager : MonoBehaviour
{
    [SerializeField] private PointList pointList;

    public void Level1Restart()
    {
        //Any thing we want the game to restart

        pointList.Reset();
    }
}
