using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AudioListScriptableObject), true)]
public class AudioListEditor : Editor
{
	#region Serialized Property
	private SerializedProperty m_audioDatasSerializedProperty;
	#endregion

	#region Unity Methods
	private void OnEnable()
    {
		#region Find Serialized Properties
		m_audioDatasSerializedProperty = serializedObject.FindProperty("m_audioDatas");
        #endregion
    }
	#endregion

	#region Custom Editor View
	public override void OnInspectorGUI()
    {
		//Load Variables 
		AudioListScriptableObject audioList = (AudioListScriptableObject)target;

		//Update the serialized object in the inspector
		serializedObject.Update();

		//Script reference
		GUI.enabled = false;
		EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((AudioListScriptableObject)target), typeof(AudioListScriptableObject), false);
		GUI.enabled = true;

		//Make a space in the editor
		EditorGUILayout.Space();

		//Create a tile section
		GUILayout.Label("Audio List Data", EditorStyles.boldLabel);

		//User Inputs
		EditorGUILayout.PropertyField(m_audioDatasSerializedProperty, new GUIContent("Audio Datas"));

		//Apply changes
		serializedObject.ApplyModifiedProperties();

		//Save data when using press save project from file dropdown menu in the menutool bar
		EditorUtility.SetDirty(target);

		//Draws default ui (testing only)
		//base.OnInspectorGUI();
	}
	#endregion
}
