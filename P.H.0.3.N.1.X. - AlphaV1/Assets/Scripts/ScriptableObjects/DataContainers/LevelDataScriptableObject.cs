using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/Data Containers/Level Data")]
public class LevelDataScriptableObject : ScriptableObject
{
    public string id;
    public string levelName;
    public int buildindex;
    public bool unlockLevel = false;
}
