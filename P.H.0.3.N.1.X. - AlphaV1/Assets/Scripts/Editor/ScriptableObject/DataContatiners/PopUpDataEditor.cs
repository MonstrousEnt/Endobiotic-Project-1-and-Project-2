using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PopUpDataScriptableObject), true)]
public class PopUpDataEditor : Editor
{
	#region Serialized Property
	SerializedProperty m_popUpAction;
	#endregion

	#region Unity Methods
	private void OnEnable()
	{
		#region Find Serialized Properties
		m_popUpAction = serializedObject.FindProperty("popUpActionUnityEvent");
		#endregion
	}
	#endregion

	#region Custom Editor View
	public override void OnInspectorGUI()
	{
		//Load Variables
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

		//User Input 
		popUpData.message = EditorGUILayout.TextField("Message", popUpData.message);
		popUpData.isConfirm = EditorGUILayout.Toggle("Is Confirm", popUpData.isConfirm);
		popUpData.isReadyToClose = EditorGUILayout.Toggle("Is Ready To Close", popUpData.isReadyToClose);

		EditorGUILayout.Space();

		EditorGUILayout.PropertyField(m_popUpAction, new GUIContent("Pop Up Action"));

		//Apply changes
		serializedObject.ApplyModifiedProperties();

		//Save data when using press save project 
		EditorUtility.SetDirty(target);

		//Draws default ui (testing only)
		//base.OnInspectorGUI();
	}
	#endregion
}