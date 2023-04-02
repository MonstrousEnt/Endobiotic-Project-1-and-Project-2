using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PointList", menuName = "Scriptable Objects/Lists/Point List - OLD")]
public class PointList : ScriptableObject
{
    public List<PiontData> treausresCollectedPointDatas = new List<PiontData>();
    public List<PiontData> puzzleOnePointDatas = new List<PiontData>();
    public List<PiontData> puzzleTwoPointDatas = new List<PiontData>();
    public List<PiontData> puzzleThreePointDatas = new List<PiontData>();
    public List<PiontData> puzzleFourPointDatas = new List<PiontData>();

    public void AddToTheCollectPointsList(PiontData piontData, PuzzlePointsList currPuzzlePointsList)
    {
        if (PuzzlePointsList.puzzleOne == currPuzzlePointsList)
        {
            puzzleOnePointDatas.Add(piontData);
        }
        else if (PuzzlePointsList.puzzleTwo == currPuzzlePointsList)
        {
            puzzleTwoPointDatas.Add(piontData);
        }
        else if(PuzzlePointsList.puzzleThree == currPuzzlePointsList)
        {
            puzzleThreePointDatas.Add(piontData);
        }
        else if(PuzzlePointsList.puzzleFour == currPuzzlePointsList)
        {
            puzzleFourPointDatas.Add(piontData);
        }
        else if(PuzzlePointsList.treausres == currPuzzlePointsList)
        {
            treausresCollectedPointDatas.Add(piontData);
        }
    }

    public int AddAllPointForAList(List<PiontData> piontDatas)
    {
        int total = 0;

        for (int i = 0; i < piontDatas.Count; i++)
        {
            total += piontDatas[i].amount;
        }

        return total;
    }

    public void Reset()
    {
        treausresCollectedPointDatas.Clear();
        puzzleOnePointDatas.Clear();
        puzzleTwoPointDatas.Clear();
        puzzleThreePointDatas.Clear();
        puzzleFourPointDatas.Clear();
    }

    private void OnEnable()
    {
        Reset();
    }
}
