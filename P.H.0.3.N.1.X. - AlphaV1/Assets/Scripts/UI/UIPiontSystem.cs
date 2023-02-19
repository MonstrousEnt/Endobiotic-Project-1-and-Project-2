using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPiontSystem : MonoBehaviour
{
    [SerializeField] private PointList pointList;

    [SerializeField] private TextMeshProUGUI pointsTextBox;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    DisplayPoints();
        //}
    }

    void DisplayPoints()
    {
        int pointFullTotal = 0;

        pointsTextBox.text = "";

        //To Do Update this
        //for (int i = 0; i < pointList.CollectedpiontDatas.Count; i++)
        //{
        //    pointsTextBox.text += pointList.CollectedpiontDatas[i].piontName + " " + pointList.CollectedpiontDatas[i].amount + "\n";
        //    pointFullTotal += pointList.CollectedpiontDatas[i].amount;
        //}

        pointsTextBox.text += "\n\n" + pointFullTotal.ToString();


        
    }
}
