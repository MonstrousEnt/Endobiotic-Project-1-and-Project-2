using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundList", menuName = "Scriptable Objects/Sound List")]
public class SoundList : ScriptableObject
{
    public List<SoundData> soundEffects;
    public List<SoundData> soundtracks;
}
