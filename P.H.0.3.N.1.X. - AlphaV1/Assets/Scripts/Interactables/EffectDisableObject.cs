using UnityEngine;

public class EffectDisableObject : MonoBehaviour
{
   [SerializeField] private SoundData soundDataSolvePuzzle;
   [SerializeField] private PiontData piontDataDoors;
   [SerializeField] private PointList pointList;
   [SerializeField] private PuzzlePointsList currPuzzlePointsList;

    public void DisableObject()
    {
        GameMangerRootMaster.instance.audioManager.PlayAudio(soundDataSolvePuzzle);

        pointList.AddToTheCollectPointsList(piontDataDoors, currPuzzlePointsList);

        gameObject.SetActive(false);
    }
}
