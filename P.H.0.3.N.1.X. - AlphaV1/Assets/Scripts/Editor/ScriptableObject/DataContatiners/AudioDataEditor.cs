using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AudioDataScriptableObject), true)]
public class AudioDataEditor : Editor
{
	private AudioSource m_audioPreviewer;

	#region Serialized Property
	private SerializedProperty m_clipSerializedProperty;
	private SerializedProperty m_audioGameObjectNameSerializedProperty;
	private SerializedProperty m_volumeSerializedProperty;
	private SerializedProperty m_pitchSerializedProperty;
	private SerializedProperty m_loopSerializedProperty;
	private SerializedProperty m_playOnAwakeSerializedProperty;
	#endregion

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

		#region Find Serialized Properties
		m_clipSerializedProperty = serializedObject.FindProperty("m_clip");
		m_audioGameObjectNameSerializedProperty = serializedObject.FindProperty("m_audioGameObjectName");
		m_volumeSerializedProperty = serializedObject.FindProperty("m_volume");
		m_pitchSerializedProperty = serializedObject.FindProperty("m_pitch");
		m_loopSerializedProperty = serializedObject.FindProperty("m_loop");
		m_playOnAwakeSerializedProperty = serializedObject.FindProperty("m_playOnAwake");
		#endregion
	}

	public void OnDisable()
	{
		DestroyImmediate(m_audioPreviewer.gameObject);
	}
	#endregion

	#region Custom Editor View
	public override void OnInspectorGUI()
	{
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

		//User Inputs 
		EditorGUILayout.PropertyField(m_clipSerializedProperty, new GUIContent("Clip"));
		EditorGUILayout.PropertyField(m_audioGameObjectNameSerializedProperty, new GUIContent("Game Object Name"));
		EditorGUILayout.PropertyField(m_volumeSerializedProperty, new GUIContent("Volume"));
		EditorGUILayout.PropertyField(m_pitchSerializedProperty, new GUIContent("Pitch"));
		EditorGUILayout.PropertyField(m_loopSerializedProperty, new GUIContent("Loop"));
		EditorGUILayout.PropertyField(m_playOnAwakeSerializedProperty, new GUIContent("Play On Awake"));

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
