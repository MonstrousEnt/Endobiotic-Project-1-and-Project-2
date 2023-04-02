using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameInstructionList", menuName = "Scriptable Objects/Lists/Game Instruction List - OLD")]
public class GameInstructionList : ScriptableObject
{
    public List<GameInstructionData> gameInstructionDatas = new List<GameInstructionData>();
}
