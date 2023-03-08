using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioList", menuName = "Scriptable Objects/Lists/Audio List")]
public class AudioListScriptableObject : ScriptableObject
{
    [SerializeField] private List<AudioDataScriptableObject> m_audioDatas = new List<AudioDataScriptableObject>();

    public List<AudioDataScriptableObject> audioDatas { get { return m_audioDatas; } set { audioDatas = value; } } 
}
