using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TagDataScriptableObject), true)]
public class TagDataCustomEditor : Editor
{
    #region Serialized Property
    private SerializedProperty m_tagNameSerializedProperty;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        #region Find Serialized Properties
        m_tagNameSerializedProperty = serializedObject.FindProperty("m_tagName");
        #endregion
    }
    #endregion

    #region Custom Editor View
    public override void OnInspectorGUI()
    {
        //Load Variables
        TagDataScriptableObject tagData = (TagDataScriptableObject)target; //Get Scriptable Object Inspector

        //Update the serialized object in the inspector
        serializedObject.Update();

        //Script reference
        GUI.enabled = false;
        EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((TagDataScriptableObject)target), typeof(TagDataScriptableObject), false);
        GUI.enabled = true;

        //Make a space in the editor
        EditorGUILayout.Space();

        //Create a tile section the Data Variables
        EditorGUILayout.LabelField("Tag Data", EditorStyles.boldLabel);

        //User Inputs 
        EditorGUILayout.PropertyField(m_tagNameSerializedProperty, new GUIContent("Name")); //Tag Name

        //Apply changes
        serializedObject.ApplyModifiedProperties();

        //Save data when using press save project from file dropdown menu in the menutool bar
        EditorUtility.SetDirty(target);

        //Draws default ui(testing only)
        //base.OnInspectorGUI();
    }
    #endregion
}
