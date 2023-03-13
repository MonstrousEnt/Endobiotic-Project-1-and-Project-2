/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 7, 2023
 * Last Updated: March 12, 2023
 * Description: This is the editor class for Scriptable Object data container audio data.
 * Notes: 
 * Resources: 
 *	Fight That OCD (CUSTOM INSPECTOR Unity): https://youtu.be/xFtFWmiW7IE
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AudioDataScriptableObject), true)]
public class AudioDataEditor : Editor
{
    #region Class Variables
    private AudioSource m_audioPreviewer;
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

	}

	public void OnDisable()
	{
		DestroyImmediate(m_audioPreviewer.gameObject);
	}
	#endregion

	#region Custom Editor View
	public override void OnInspectorGUI()
	{
		//Local Variables
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
		audioData.clip = (AudioClip)EditorGUILayout.ObjectField("Clip", audioData.clip, typeof(AudioClip), true);
		audioData.audioGameObjectName = EditorGUILayout.TextField("Game Object Name", audioData.audioGameObjectName);
		audioData.volume = EditorGUILayout.Slider("Volume", audioData.volume, 0f, 1f);
		audioData.pitch = EditorGUILayout.Slider("Pitch", audioData.pitch, 0f, 3f);
		audioData.loop = EditorGUILayout.Toggle("Loop", audioData.loop);
		audioData.playOnAwake = EditorGUILayout.Toggle("Play On Awake", audioData.playOnAwake);

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
