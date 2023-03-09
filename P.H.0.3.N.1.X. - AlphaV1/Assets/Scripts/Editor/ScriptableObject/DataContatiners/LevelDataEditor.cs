using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelDataScriptableObject), true)]
public class LevelDataEditor : Editor
{
	#region Serialized Property
	private SerializedProperty m_levelIDSerializedProperty;
	private SerializedProperty m_levelNameSerializedProperty;
	private SerializedProperty m_buildIndexSerializedProperty;
	private SerializedProperty m_unlockLevelSerializedProperty;
	#endregion

	#region Unity Methods
	private void OnEnable()
	{
		#region Find Serialized Properties
		m_levelIDSerializedProperty = serializedObject.FindProperty("m_levelID");
		m_levelNameSerializedProperty = serializedObject.FindProperty("m_levelName");
		m_buildIndexSerializedProperty = serializedObject.FindProperty("m_buildIndex");
		m_unlockLevelSerializedProperty = serializedObject.FindProperty("m_unlockLevel");
		#endregion
	}
	#endregion

	public override void OnInspectorGUI()
	{
		//Load Variables
		LevelDataScriptableObject levelData = (LevelDataScriptableObject)target;

		//Update the serialized object in the inspector
		serializedObject.Update();

		//Script reference
		GUI.enabled = false;
		EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((LevelDataScriptableObject)target), typeof(LevelDataScriptableObject), false);
		GUI.enabled = true;

		//Make a space in the editor
		EditorGUILayout.Space();

		//Create a tile section 
		GUILayout.Label("Level Data", EditorStyles.boldLabel);

		//User Inputs 
		EditorGUILayout.PropertyField(m_levelIDSerializedProperty, new GUIContent("ID"));
		EditorGUILayout.PropertyField(m_levelNameSerializedProperty, new GUIContent("Name"));
		EditorGUILayout.PropertyField(m_buildIndexSerializedProperty, new GUIContent("Build Index"));
		EditorGUILayout.PropertyField(m_unlockLevelSerializedProperty ,new GUIContent("Unlock Level"));

		//Apply changes
		serializedObject.ApplyModifiedProperties();

		//Save data when using press save project 
		EditorUtility.SetDirty(target);

		//Draws default ui (testing only)
		//base.OnInspectorGUI();
	}
}
