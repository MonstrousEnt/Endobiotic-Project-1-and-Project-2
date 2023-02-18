using System.Collections;
using UnityEngine;

public class TreasureObject : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject HPointsGameObject;

    [SerializeField] private PiontData piontData;
    [SerializeField] private PointList pointList;

    [SerializeField] private float animationTime;

    [SerializeField] private SoundData soundDataPickUpItem;

    private void Start()
    {
        HPointsGameObject.SetActive(false);
    }

    public void PickupTreasure()
    {
        pointList.AddToTheCollectPointsList(pointList.treausresCollectedPointDatas, piontData);

        GameMangerRootMaster.instance.audioManager.PlayAudio(soundDataPickUpItem);

        StopCoroutine(chestAnimatiom());
        StartCoroutine(chestAnimatiom());
    }

   private IEnumerator chestAnimatiom()
   {
        HPointsGameObject.SetActive(true);

        animator.Play("pointsfound");

        yield return new WaitForSeconds(animationTime);

        HPointsGameObject.SetActive(false);
   }
}
