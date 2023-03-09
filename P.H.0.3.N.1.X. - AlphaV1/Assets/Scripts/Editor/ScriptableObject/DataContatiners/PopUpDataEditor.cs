using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PopUpDataScriptableObject), true)]
public class PopUpDataEditor : Editor
{
	#region Serialized Property
	SerializedProperty m_messageSerializedProperty;
	SerializedProperty m_isConfrimSerializedProperty;
	SerializedProperty m_isReadyToCloseSerializedProperty;
	SerializedProperty m_popUpActionUnityEventSerializedProperty;
	#endregion

	#region Unity Methods
	private void OnEnable()
	{
		#region Find Serialized Properties
		m_messageSerializedProperty = serializedObject.FindProperty("m_message");
		m_isConfrimSerializedProperty = serializedObject.FindProperty("m_isConfrim");
		m_isReadyToCloseSerializedProperty = serializedObject.FindProperty("m_isReadyToClose");
		m_popUpActionUnityEventSerializedProperty = serializedObject.FindProperty("m_popUpActionUnityEvent");
		#endregion
	}
	#endregion

	#region Custom Editor View
	public override void OnInspectorGUI()
	{
		PopUpDataScriptableObject popUpData = (PopUpDataScriptableObject)target;

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
		EditorGUILayout.PropertyField(m_messageSerializedProperty ,new GUIContent("Message"));
		EditorGUILayout.PropertyField(m_isConfrimSerializedProperty, new GUIContent("Is Confirm"));
		EditorGUILayout.PropertyField(m_isReadyToCloseSerializedProperty, new GUIContent("Is Ready To Close"));

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