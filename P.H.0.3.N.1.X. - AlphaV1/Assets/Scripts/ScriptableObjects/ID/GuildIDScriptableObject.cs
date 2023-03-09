using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GuildID", menuName = "Scriptable Objects/ID/Guild ID")]
public class GuildIDScriptableObject : ScriptableObject
{
    [SerializeField] private string m_guildID;

    public void GenId()
    {
        m_guildID = Guid.NewGuid().ToString();
    }
}
