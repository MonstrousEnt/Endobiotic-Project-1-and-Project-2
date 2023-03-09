using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/Data Containers/Level Data")]
public class LevelDataScriptableObject : ScriptableObject
{
    [SerializeField] private string m_levelID;
    [SerializeField] private string m_levelName;
    [SerializeField] private int m_buildIndex;
    [SerializeField] private bool m_unlockLevel;

    #region Getters and Setters
    public string id { get { return m_levelID; } set { m_levelID = value; } }
    public string levelName { get { return m_levelName; } set { m_levelName = value; } }
    public int buildindex { get { return m_buildIndex; } set { m_buildIndex = value; } }
    public bool unlockLevel { get { return m_unlockLevel; } set { m_unlockLevel = value; } }
    #endregion
}
