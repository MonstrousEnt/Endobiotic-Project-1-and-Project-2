/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 8, 2023
 * Last Updated: March 30, 2023
 * Description: This is the editor class for Scriptable Object List audio List.
 * Notes: 
 * Resources: 
 *	Fight That OCD (CUSTOM INSPECTOR Unity): https://youtu.be/xFtFWmiW7IE
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AudioListScriptableObject), true)]
public class AudioListEditor : Editor
{
    #region Class Variables
		#region Serialized Property
		private SerializedProperty m_audioDatasSerializedProperty;
		#endregion
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
		//Local Variables
		AudioListScriptableObject l_audioList = (AudioListScriptableObject)target;

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

		//Save data when using press save project 
		EditorUtility.SetDirty(target);

		//Draws default ui (testing only)
		//base.OnInspectorGUI();
	}
	#endregion
}
