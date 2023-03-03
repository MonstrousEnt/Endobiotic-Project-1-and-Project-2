using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/Audio Data")]
public class AudioDataScriptableObject : ScriptableObject
{
	public AudioClip clip;

	public string audioName;

	[Range(0f, 1f)]
	public float volume;

	[Range(.1f, 3f)]
	public float pitch;

	public bool loop;

	public void PlaySound(AudioSource source)
	{
		source.clip = clip;
		source.volume = volume;
		source.pitch = pitch;
		source.loop = loop;
		source.Play();
	}

	public void StopSound(AudioSource source)
    {
		source.Stop();
	}

	public void EnableLoop()
	{
		loop = true;
	}
}

#if UNITY_EDITOR
[CustomEditor(typeof(AudioDataScriptableObject), true)]
public class AudioEventEditor : Editor
{
	[SerializeField] private AudioSource m_previewer;

	public void OnEnable()
	{
		m_previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
	}

	public void OnDisable()
	{
		DestroyImmediate(m_previewer.gameObject);
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		EditorGUILayout.Space();

		if (GUILayout.Button("Play Preview"))
		{
			((AudioDataScriptableObject)target).PlaySound(m_previewer);
		}

		if (GUILayout.Button("Stop Preview"))
		{
			((AudioDataScriptableObject)target).StopSound(m_previewer);
		}
	}
}
#endif