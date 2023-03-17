using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameInstructionData", menuName = "Scriptable Objects/Data Containers/Game Instruction Data - OLD")]
public class GameInstructionData : ScriptableObject
{
    public string gameInstructionName;
    public Sprite image;
    public string description;
}
