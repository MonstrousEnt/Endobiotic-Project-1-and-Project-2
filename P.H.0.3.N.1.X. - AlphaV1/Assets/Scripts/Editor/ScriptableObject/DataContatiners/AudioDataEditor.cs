/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 7, 2023
 * Last Updated: March 30, 2023
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
    private void playPreview(AudioSource a_source, AudioDataScriptableObject a_audioData)
	{
		a_source.clip = a_audioData.clip;
		a_source.volume = a_audioData.volume;
		a_source.pitch = a_audioData.pitch;

		a_source.Play();
	}

	private void stopPreview(AudioSource a_source)
	{
		a_source.Stop();
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
		AudioDataScriptableObject l_audioData = (AudioDataScriptableObject)target;

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
		l_audioData.clip = (AudioClip)EditorGUILayout.ObjectField("Clip", l_audioData.clip, typeof(AudioClip), true);
		l_audioData.audioGameObjectName = EditorGUILayout.TextField("Game Object Name", l_audioData.audioGameObjectName);
		l_audioData.volume = EditorGUILayout.Slider("Volume", l_audioData.volume, 0f, 1f);
		l_audioData.pitch = EditorGUILayout.Slider("Pitch", l_audioData.pitch, 0f, 3f);
		l_audioData.loop = EditorGUILayout.Toggle("Loop", l_audioData.loop);
		l_audioData.playOnAwake = EditorGUILayout.Toggle("Play On Awake", l_audioData.playOnAwake);

		EditorGUILayout.Space();

		//Buttons
		if (GUILayout.Button("Play Preview"))
		{
			playPreview(m_audioPreviewer, l_audioData);
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
