using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


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

	[HideInInspector]
	private AudioSource source;

	public void PlayPreview(AudioSource source)
	{
		source.clip = clip;
		source.volume = volume;
		source.pitch = pitch;
		source.Play();
	}

	public void StopPreview(AudioSource source)
    {
		source.Stop();
	}

	public void PlaySound()
    {
		if (source == null) 
		{
			GameObject audioGameObject = new GameObject(audioName);
			AudioSource audioSource = audioGameObject.AddComponent<AudioSource>();

			audioSource.clip = clip;
			audioSource.volume = volume;
			audioSource.pitch = pitch;
			audioSource.loop = loop;
			source = audioSource;
		}

		if (source != null)
        {
			source.Play();
        }

	}

	public void StopSound()
	{
		if (source != null)
		{
			source.loop = false;
			source.Stop();
		}
	}

	public void EnableLoop()
	{
		loop = true;
	}
}

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
			((AudioDataScriptableObject)target).PlayPreview(m_previewer);
		}

		if (GUILayout.Button("Stop Preview"))
		{
			((AudioDataScriptableObject)target).StopPreview(m_previewer);
		}
	}
}