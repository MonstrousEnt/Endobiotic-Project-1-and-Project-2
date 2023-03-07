using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/Data Containers/Audio Data")]
public class AudioDataScriptableObject : ScriptableObject
{
	public AudioClip clip;
	public string audioGameObjectName;
	public float volume;
	public float pitch;
	public bool loop;

	[HideInInspector] public AudioSource source;

    private void OnEnable()
    {
		source = null;
    }
}