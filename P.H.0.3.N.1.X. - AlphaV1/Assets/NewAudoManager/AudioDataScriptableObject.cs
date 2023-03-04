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

	private AudioSource source;

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
			source.loop = loop;

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
		AudioDataScriptableObject audioData = (AudioDataScriptableObject)target;

		DrawDefaultInspector();

		EditorGUILayout.Space();

		if (GUILayout.Button("Play Preview"))
		{
			playPreview(m_previewer, audioData);
		}

		if (GUILayout.Button("Stop Preview"))
		{
			stopPreview(m_previewer);
		}
	}

	private void playPreview(AudioSource source, AudioDataScriptableObject audioData)
	{
		source.clip = audioData.clip;
		source.volume = audioData.volume;
		source.pitch = audioData.pitch;

		source.Play();
	}

	private void stopPreview(AudioSource source)
	{
		source.Stop();
	}
}
#endif