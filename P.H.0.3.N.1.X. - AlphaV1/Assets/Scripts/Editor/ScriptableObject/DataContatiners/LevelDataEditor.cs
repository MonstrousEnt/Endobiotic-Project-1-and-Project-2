using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelDataScriptableObject), true)]
public class LevelDataEditor : Editor
{
	public override void OnInspectorGUI()
	{
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
		levelData.id = EditorGUILayout.TextField("Id", levelData.id);
		levelData.levelName = EditorGUILayout.TextField("Name", levelData.levelName);
		levelData.buildindex = EditorGUILayout.IntField("Build Index", levelData.buildindex);
		levelData.unlockLevel = EditorGUILayout.Toggle("Unlock Level", levelData.unlockLevel);

		//Apply changes
		serializedObject.ApplyModifiedProperties();

		//Save data when using press save project 
		EditorUtility.SetDirty(target);

		//Draws default ui (testing only)
		//base.OnInspectorGUI();
	}
}
