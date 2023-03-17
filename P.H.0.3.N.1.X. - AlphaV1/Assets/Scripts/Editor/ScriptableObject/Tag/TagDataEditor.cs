/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 7, 2023
 * Last Updated: March 12, 2023
 * Description: This is the editor class for Scriptable Object Tag tag data.
 * Notes: 
 * Resources: 
 *	Fight That OCD (CUSTOM INSPECTOR Unity): https://youtu.be/xFtFWmiW7IE
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TagDataScriptableObject), true)]
public class TagDataEditor : Editor
{
    #region Custom Editor View
    public override void OnInspectorGUI()
    {
        //Local Variables
        TagDataScriptableObject tagData = (TagDataScriptableObject)target; 

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
        tagData.tagName = EditorGUILayout.TagField(new GUIContent("Name"), tagData.tagName);

        //Apply changes
        serializedObject.ApplyModifiedProperties();

        //Save data when using press save project 
        EditorUtility.SetDirty(target);

        //Draws default ui(testing only)
        //base.OnInspectorGUI();
    }
    #endregion
}
