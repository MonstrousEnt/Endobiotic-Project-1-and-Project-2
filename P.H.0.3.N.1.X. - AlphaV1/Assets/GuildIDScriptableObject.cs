using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "GuildID", menuName = "Scriptable Objects/GuildID")]
public class GuildIDScriptableObject : ScriptableObject
{
    public string id;

    public void GenId()
    {
        id = Guid.NewGuid().ToString();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(GuildIDScriptableObject), true)]
public class GuildIDCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {

        GuildIDScriptableObject guildID = (GuildIDScriptableObject)target; 

        serializedObject.Update();

        GUI.enabled = false; 
        EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((GuildIDScriptableObject)target), typeof(GuildIDScriptableObject), false);
        GUI.enabled = true;

        EditorGUILayout.Space();

        guildID.id = EditorGUILayout.TextField("Guild ID", guildID.id);

        EditorGUILayout.Space();

        if (GUILayout.Button("Gen ID"))
        {
            guildID.GenId();
        }

        serializedObject.ApplyModifiedProperties();

        EditorUtility.SetDirty(target);

        //Draws default ui(testing only)
        //base.OnInspectorGUI();
    }
}
#endif
