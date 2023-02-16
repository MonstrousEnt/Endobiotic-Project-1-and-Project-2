using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public string dialogueName;
    public Sprite portraitSprite;
    public List<string> messages;
}
