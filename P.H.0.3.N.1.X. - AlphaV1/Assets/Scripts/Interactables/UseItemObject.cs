using UnityEngine;

public class UseItemObject : MonoBehaviour
{
    [SerializeField] private PiontData piontData;
    [SerializeField] private PointList pointList;
    [SerializeField] private PuzzlePointsList currPuzzlePointsList;

    public void UseItem()
    {
        pointList.AddToTheCollectPointsList(piontData, currPuzzlePointsList);

        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterItemHolder>().UseItem();
    }
}
