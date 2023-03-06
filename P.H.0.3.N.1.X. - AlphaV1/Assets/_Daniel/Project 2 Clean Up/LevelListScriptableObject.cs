using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelList", menuName = "Scriptable Objects/Level List")]
public class LevelListScriptableObject : ScriptableObject
{
    public List<LevelDataScriptableObject> levelDatas = new List<LevelDataScriptableObject>();

    public int getLevelById(string id)
    {
        for (int i = 0; i < levelDatas.Count; i++)
        {
            if (levelDatas[i].id == id)
            {
                return i;
            }
        }

        return 0;
    }
}