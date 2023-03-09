using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GuildID", menuName = "Scriptable Objects/ID/Guild ID")]
public class GuildIDScriptableObject : ScriptableObject
{
    [SerializeField] private string m_id;

    public void GenId()
    {
        m_id = Guid.NewGuid().ToString();
    }
}
