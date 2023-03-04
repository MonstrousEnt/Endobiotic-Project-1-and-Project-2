using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "TagData", menuName = "Scriptable Objects/Tag Data")]
public class TagDataScriptableObject : ScriptableObject
{
    public string tagName;
}

#if UNITY_EDITOR
[CustomEditor(typeof(TagDataScriptableObject), true)]
public class TagDataCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //Load Variables
        TagDataScriptableObject tagDataConetent = (TagDataScriptableObject)target; //Get Scriptable Object Inspector

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

        //User Input 
        tagDataConetent.tagName = EditorGUILayout.TagField("Tag Name", tagDataConetent.tagName); //Tag Name

        //Apply changes
        serializedObject.ApplyModifiedProperties();

        //Save data when using press save project from file dropdown menu in the menutool bar
        EditorUtility.SetDirty(target);

        //Draws default ui(testing only)
        //base.OnInspectorGUI();
    }
}
#endif