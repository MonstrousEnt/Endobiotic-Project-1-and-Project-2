using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GuildId", menuName = "Scriptable Objects/ID/Guild Id")]
public class GuildIdScriptableObject : ScriptableObject
{
    [SerializeField] private string m_id;

    public void GenId()
    {
        m_id = Guid.NewGuid().ToString();
    }
}
