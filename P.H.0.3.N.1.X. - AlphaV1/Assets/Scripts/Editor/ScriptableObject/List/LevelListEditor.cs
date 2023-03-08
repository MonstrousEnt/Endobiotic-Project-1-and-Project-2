using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelListScriptableObject), true)]
public class LevelListEditor : Editor
{
	#region Serialized Property
	private SerializedProperty m_levelDatasSerializedProperty;
	#endregion

	#region Unity Methods
	private void OnEnable()
	{
		#region Find Serialized Properties
		m_levelDatasSerializedProperty = serializedObject.FindProperty("m_levelDatas");
		#endregion
	}
	#endregion

	#region Custom Editor View
	public override void OnInspectorGUI()
	{
		//Update the serialized object in the inspector
		serializedObject.Update();

		//Script reference
		GUI.enabled = false;
		EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((LevelListScriptableObject)target), typeof(LevelListScriptableObject), false);
		GUI.enabled = true;

		//Make a space in the editor
		EditorGUILayout.Space();

		//Create a tile section
		GUILayout.Label("Level List Data", EditorStyles.boldLabel);

		EditorGUILayout.PropertyField(m_levelDatasSerializedProperty, new GUIContent("Level Datas"));

		//Apply changes
		serializedObject.ApplyModifiedProperties();

		//Draws default ui (testing only)
		//base.OnInspectorGUI();
	}
	#endregion
}
