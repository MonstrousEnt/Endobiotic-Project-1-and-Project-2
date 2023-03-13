/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 7, 2023
 * Last Updated: March 12, 2023
 * Description: This is the editor class for Scriptable Object data container level data.
 * Notes: 
 * Resources: 
 *	Fight That OCD (CUSTOM INSPECTOR Unity): https://youtu.be/xFtFWmiW7IE
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelDataScriptableObject), true)]
public class LevelDataEditor : Editor
{
	#region Custom Editor View
	public override void OnInspectorGUI()
	{
		//Local Variables
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
	#endregion
}
