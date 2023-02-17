using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "SoundData", menuName = "Scriptable Objects/Sound Data")]
public class SoundData : ScriptableObject
{
    public string soundName;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}

#if UNITY_EDITOR
[CustomEditor(typeof(SoundData), true)]
public class LevelDataCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ////Load Variables
        //SoundData soundDataConetent = (SoundData)target; //Get Scriptable Object Inspector

        ////Update the serialized object in the inspector
        //serializedObject.Update();

        ////Script reference
        //GUI.enabled = false; //make this read only field
        //EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((SoundData)target), typeof(SoundData), false);

        //GUI.enabled = true;

        ////Make a space in the editor
        //EditorGUILayout.Space();

        ////Create a tile section for Sound Data Variables
        //EditorGUILayout.LabelField("Sound Data", EditorStyles.boldLabel);

        ////User Input 
        //soundDataConetent.clip = (AudioClip)EditorGUILayout.ObjectField("Cilp", soundDataConetent.clip, typeof(AudioClip), true); //Clip
        //soundDataConetent.soundName = EditorGUILayout.TextField("Name", soundDataConetent.soundName); //Name
        //soundDataConetent.volume = EditorGUILayout.FloatField("Volume", soundDataConetent.volume); //Volume
        //soundDataConetent.pitch = EditorGUILayout.FloatField("Pitch", soundDataConetent.pitch); //Pitch
        //soundDataConetent.loop = EditorGUILayout.Toggle("Loop", soundDataConetent.loop); //Loop
        //soundDataConetent.playOnAwake = EditorGUILayout.Toggle("Play On Awake", soundDataConetent.playOnAwake); //Play on Awake


        ////Apply changes
        //serializedObject.ApplyModifiedProperties();

        ////Save data when using press save project from file dropdown menu in the menutool bar
        //EditorUtility.SetDirty(target);

        ////Play Button
        ////if  (GUILayout.Button("Play"))
        ////{
        ////    soundDataConetent.SetupAudioSource();
        ////    soundDataConetent.PlayAudio();
        ////}

        //Draws default ui(testing only)
        base.OnInspectorGUI();
    }
}
#endif
