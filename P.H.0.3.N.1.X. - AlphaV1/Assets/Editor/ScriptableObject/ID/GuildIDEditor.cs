using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GuildIDScriptableObject), true)]
public class GuildIDEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //Load Variables
        GuildIDScriptableObject guildID = (GuildIDScriptableObject)target;

        //Update the serialized object in the inspector
        serializedObject.Update();

        //Script reference
        GUI.enabled = false;
        EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((GuildIDScriptableObject)target), typeof(GuildIDScriptableObject), false);
        GUI.enabled = true;

        //Make a space in the editor
        EditorGUILayout.Space();

        //Create a tile section 
        GUILayout.Label("Guild Id", EditorStyles.boldLabel);

        guildID.id = EditorGUILayout.TextField("Id", guildID.id);

        EditorGUILayout.Space();

        //Buttons
        if (GUILayout.Button("Gen ID"))
        {
            guildID.GenId();
        }

        //Apply changes
        serializedObject.ApplyModifiedProperties();

        //Save data when using press save project 
        EditorUtility.SetDirty(target);

        //Draws default ui (testing only)
        //base.OnInspectorGUI();
    }
}
