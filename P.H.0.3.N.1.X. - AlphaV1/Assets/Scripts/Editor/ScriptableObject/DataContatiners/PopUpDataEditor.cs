/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 7, 2023
 * Last Updated: March 30, 2023
 * Description: This is the editor class for Scriptable Object data container pop up data.
 * Notes: 
 * Resources: 
 *	Fight That OCD (CUSTOM INSPECTOR Unity): https://youtu.be/xFtFWmiW7IE
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PopUpDataScriptableObject), true)]
public class PopUpDataEditor : Editor
{
	#region Class Variables
		#region Serialized Property
		SerializedProperty m_popUpActionUnityEventSerializedProperty;
		#endregion
    #endregion

    #region Unity Methods
    private void OnEnable()
	{
		#region Find Serialized Properties
		m_popUpActionUnityEventSerializedProperty = serializedObject.FindProperty("m_popUpActionUnityEvent");
		#endregion
	}
	#endregion

	#region Custom Editor View
	public override void OnInspectorGUI()
	{
		//Local Variables
		PopUpDataScriptableObject l_popUpData = (PopUpDataScriptableObject)target;

		//Update the serialized object in the inspector
		serializedObject.Update();

		//Script reference
		GUI.enabled = false;
		EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((PopUpDataScriptableObject)target), typeof(PopUpDataScriptableObject), false);
		GUI.enabled = true;

		//Make a space in the editor
		EditorGUILayout.Space();

		//Create a tile section
		GUILayout.Label("Pop Up Data", EditorStyles.boldLabel);

		//User Inputs 
		l_popUpData.message = EditorGUILayout.TextField("Message", l_popUpData.message);
		l_popUpData.isConfirm = EditorGUILayout.Toggle("Is Confirm", l_popUpData.isConfirm);
		l_popUpData.isReadyToClose = EditorGUILayout.Toggle("Is Ready To Close", l_popUpData.isReadyToClose);

		EditorGUILayout.Space();

		EditorGUILayout.PropertyField(m_popUpActionUnityEventSerializedProperty, new GUIContent("Pop Up Action"));

		//Apply changes
		serializedObject.ApplyModifiedProperties();

		//Save data when using press save project 
		EditorUtility.SetDirty(target);

		//Draws default ui (testing only)
		//base.OnInspectorGUI();
	}
	#endregion
}