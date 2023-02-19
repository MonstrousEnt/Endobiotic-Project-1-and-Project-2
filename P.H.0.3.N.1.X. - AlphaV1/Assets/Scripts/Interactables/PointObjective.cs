using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointObjective : MonoBehaviour
{
    [SerializeField] private PiontData piontData;
    [SerializeField] private PointList pointList;
    [SerializeField] private PuzzlePointsList currPuzzlePointsList;

    public void AddPoints()
    {
        pointList.AddToTheCollectPointsList(piontData, currPuzzlePointsList);
    }    
}
