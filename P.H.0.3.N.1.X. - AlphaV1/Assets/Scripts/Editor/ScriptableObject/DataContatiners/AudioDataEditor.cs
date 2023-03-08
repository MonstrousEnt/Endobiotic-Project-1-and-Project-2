using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AudioDataScriptableObject), true)]
public class AudioDataEditor : Editor
{
	private AudioSource m_audioPreviewer;

	#region Custom Editor Methods - Buttons
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
	#endregion

	#region Unity Methods
	public void OnEnable()
	{
		m_audioPreviewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
	}

	public void OnDisable()
	{
		DestroyImmediate(m_audioPreviewer.gameObject);
	}
	#endregion

	#region Custom Editor View
	public override void OnInspectorGUI()
	{
		//Load Variables
		AudioDataScriptableObject audioData = (AudioDataScriptableObject)target;

		//Update the serialized object in the inspector
		serializedObject.Update();

		//Script reference
		GUI.enabled = false;
		EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((AudioDataScriptableObject)target), typeof(AudioDataScriptableObject), false);
		GUI.enabled = true;

		//Make a space in the editor
		EditorGUILayout.Space();

		//Create a tile section 
		GUILayout.Label("Audio Data", EditorStyles.boldLabel);

		//User Input 
		audioData.clip = (AudioClip)EditorGUILayout.ObjectField("Clip", audioData.clip, typeof(AudioClip), true);
		audioData.audioGameObjectName = EditorGUILayout.TextField("Game Object Name", audioData.audioGameObjectName);
		audioData.volume = EditorGUILayout.Slider("Volume", audioData.volume, 0f, 1f);
		audioData.pitch = EditorGUILayout.Slider("Pitch", audioData.pitch, 0f, 3f);
		audioData.loop = EditorGUILayout.Toggle("Loop", audioData.loop);

		EditorGUILayout.Space();

		//Buttons
		if (GUILayout.Button("Play Preview"))
		{
			playPreview(m_audioPreviewer, audioData);
		}

		if (GUILayout.Button("Stop Preview"))
		{
			stopPreview(m_audioPreviewer);
		}

		//Apply changes
		serializedObject.ApplyModifiedProperties();

		//Save data when using press save project 
		EditorUtility.SetDirty(target);

		//Draws default ui (testing only)
		//base.OnInspectorGUI();
	}
	#endregion
}
