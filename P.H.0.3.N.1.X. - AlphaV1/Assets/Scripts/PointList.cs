using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PointList", menuName = "Scriptable Objects/Point List")]
public class PointList : ScriptableObject
{
    public List<PiontData> CollectedpiontDatas = new List<PiontData>();

    public void Reset()
    {
        CollectedpiontDatas.Clear();
    }
}
