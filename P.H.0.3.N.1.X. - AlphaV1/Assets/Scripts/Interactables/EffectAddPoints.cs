using UnityEngine;

public class EffectAddPoints : MonoBehaviour
{
    [SerializeField] private PiontData piontData;
    [SerializeField] private PointList pointList;
    [SerializeField] private PuzzlePointsList currPuzzlePointsList;

    public void AddPoints()
    {
        pointList.AddToTheCollectPointsList(piontData, currPuzzlePointsList);
    }    
}
