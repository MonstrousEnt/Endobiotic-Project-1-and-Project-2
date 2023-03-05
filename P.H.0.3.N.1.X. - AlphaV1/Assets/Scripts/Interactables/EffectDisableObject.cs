using UnityEngine;
using UnityEngine.Events;

public class EffectDisableObject : MonoBehaviour
{
   [SerializeField] private PiontData piontDataDoors;
   [SerializeField] private PointList pointList;
   [SerializeField] private PuzzlePointsList currPuzzlePointsList;

    [SerializeField] private UnityEvent soundEffectUnityEvent;

    public void DisableObject()
    {
        soundEffectUnityEvent.Invoke();

        pointList.AddToTheCollectPointsList(piontDataDoors, currPuzzlePointsList);

        gameObject.SetActive(false);
    }
}
