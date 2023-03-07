using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GuildID", menuName = "Scriptable Objects/ID/GuildID")]
public class GuildIDScriptableObject : ScriptableObject
{
    public string id;

    public void GenId()
    {
        id = Guid.NewGuid().ToString();
    }
}
