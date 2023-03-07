using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/Data Containers/Dialogue Data - OLD")]
public class DialogueData : ScriptableObject
{
    public string dialogueName;
    public Sprite portraitSprite;
    public List<string> messages;
}
