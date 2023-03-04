using UnityEngine;

public class EffectUseItem : MonoBehaviour
{
    [SerializeField] private PiontData piontData;
    [SerializeField] private PointList pointList;
    [SerializeField] private PuzzlePointsList currPuzzlePointsList;

    [SerializeField] private TagDataScriptableObject tagDataPlayer;

    public void UseItem()
    {
        pointList.AddToTheCollectPointsList(piontData, currPuzzlePointsList);

        GameObject.FindGameObjectWithTag(tagDataPlayer.tagName).GetComponent<CharacterItemHolder>().UseItem();
    }
}
