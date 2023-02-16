using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundList", menuName = "Scriptable Objects/Sound List")]
public class SoundList : ScriptableObject
{
    public List<SoundData> soundDatas = new List<SoundData>();
}
