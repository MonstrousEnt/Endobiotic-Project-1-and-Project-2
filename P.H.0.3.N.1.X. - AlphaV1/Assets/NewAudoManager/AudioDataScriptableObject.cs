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


	private void initailizeGameObject()
    {
		GameObject audioGameObject = new GameObject(audioName);
		AudioSource audioSource = audioGameObject.AddComponent<AudioSource>();
		source = audioSource;
	}

	private void initailizeAudioData()
    {
		if (source != null)
        {
			source.clip = clip;
			source.volume = volume;
			source.pitch = pitch;
			source.loop = loop;
		}
	}

	public void PlaySound()
	{
		if (source == null)
		{
			initailizeGameObject();
		}
		
		initailizeAudioData();

		source.Play();
	}

	public void StopSound()
	{
		if (source != null)
		{
			source.loop = false;

			source.Stop();
		}
	}
}

#if UNITY_EDITOR
[CustomEditor(typeof(AudioDataScriptableObject), true)]
public class AudioEventEditor : Editor
{
	private AudioSource m_audioPreviewer;

	public void OnEnable()
	{
		m_audioPreviewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
	}

	public void OnDisable()
	{
		DestroyImmediate(m_audioPreviewer.gameObject);
	}

	public override void OnInspectorGUI()
	{
		AudioDataScriptableObject audioData = (AudioDataScriptableObject)target;

		DrawDefaultInspector();

		EditorGUILayout.Space();

		if (GUILayout.Button("Play Preview"))
		{
			playPreview(m_audioPreviewer, audioData);
		}

		if (GUILayout.Button("Stop Preview"))
		{
			stopPreview(m_audioPreviewer);
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