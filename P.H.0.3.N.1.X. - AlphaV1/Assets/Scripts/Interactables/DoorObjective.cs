using UnityEngine;

public class DoorObjective : MonoBehaviour
{
   [SerializeField] private SoundData soundDataSolvePuzzle;
   [SerializeField] private PiontData piontDataDoors;
   [SerializeField] private PointList pointList;
   [SerializeField] private PuzzlePointsList currPuzzlePointsList;

    public void DisableDoor()
    {
        GameMangerRootMaster.instance.audioManager.PlayAudio(soundDataSolvePuzzle);

        pointList.AddToTheCollectPointsList(piontDataDoors, currPuzzlePointsList);

        gameObject.SetActive(false);
    }
}
