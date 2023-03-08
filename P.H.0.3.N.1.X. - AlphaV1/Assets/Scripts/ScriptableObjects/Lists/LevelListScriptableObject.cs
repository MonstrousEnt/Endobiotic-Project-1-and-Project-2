using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelList", menuName = "Scriptable Objects/Lists/Level List")]
public class LevelListScriptableObject : ScriptableObject
{
    [SerializeField] private List<LevelDataScriptableObject> m_levelDatas = new List<LevelDataScriptableObject>();

    #region Getters and Setters
    public List<LevelDataScriptableObject> levelDatas { get { return m_levelDatas; } set { m_levelDatas = value; } }

    public int getLevelById(string id)
    {
        for (int i = 0; i < m_levelDatas.Count; i++)
        {
            if (m_levelDatas[i].id == id)
            {
                return i;
            }
        }

        return 0;
    }
    #endregion
}