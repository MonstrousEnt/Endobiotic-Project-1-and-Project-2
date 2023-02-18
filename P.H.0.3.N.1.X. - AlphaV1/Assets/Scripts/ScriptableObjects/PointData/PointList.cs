using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PointList", menuName = "Scriptable Objects/Point List")]
public class PointList : ScriptableObject
{
    public List<PiontData> treausresCollectedPointDatas = new List<PiontData>();

    public void AddToTheCollectPointsList(List<PiontData> piontDatas, PiontData piontData)
    {
        piontDatas.Add(piontData);
    }

    public void Reset()
    {
        treausresCollectedPointDatas.Clear();
    }

    private void OnEnable()
    {
        Reset();
    }
}
