using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TagData", menuName = "Scriptable Objects/Tag/Tag Data")]
public class TagDataScriptableObject : ScriptableObject
{
    [SerializeField] private string m_tagName;

    public string tagName { get { return m_tagName; } set { m_tagName = value; } }
}