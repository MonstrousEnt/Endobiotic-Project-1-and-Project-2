using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPiontSystem : MonoBehaviour
{
    [SerializeField] private PointList pointList;

    [SerializeField] private TextMeshProUGUI pointsTextBox;

    public void DisplayPoints()
    {
        int pointFullTotal = 0;

        pointsTextBox.text = "";

        pointsTextBox.text += "Puzzle 1: ";

        int puzzeOnePoints = pointList.AddAllPointForAList(pointList.puzzleOnePointDatas);

        pointsTextBox.text += puzzeOnePoints.ToString() + "\n";

        pointsTextBox.text += "Puzzle 2: ";

        int puzzeTwoPoints = pointList.AddAllPointForAList(pointList.puzzleTwoPointDatas);

        pointsTextBox.text += puzzeTwoPoints.ToString() + "\n";


        pointsTextBox.text += "Puzzle 3: ";

        int puzzeThreePoints = pointList.AddAllPointForAList(pointList.puzzleThreePointDatas);

        pointsTextBox.text += puzzeThreePoints.ToString() + "\n";


        pointsTextBox.text += "Puzzle 4: ";

        int puzzeFourPoints = pointList.AddAllPointForAList(pointList.puzzleFourPointDatas);

        pointsTextBox.text += puzzeFourPoints.ToString() + "\n";


        pointsTextBox.text += "Treasure: ";

        int ChestPoints = pointList.AddAllPointForAList(pointList.puzzleFourPointDatas);

        pointsTextBox.text += ChestPoints.ToString() + "\n";


        pointsTextBox.text += "Full Total: ";

        int fulltotal = 0;

        fulltotal = puzzeOnePoints + puzzeTwoPoints + puzzeThreePoints + puzzeFourPoints + ChestPoints;

        pointsTextBox.text += fulltotal + "\n";


        //To Do Update this


        pointsTextBox.text += "\n\n" + pointFullTotal.ToString();
    }
}
