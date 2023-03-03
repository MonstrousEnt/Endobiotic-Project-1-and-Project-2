using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameInstructionMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainWindowGameObject;

    [SerializeField] private GameInstructionList gameInstructionList;

    [SerializeField] private TextMeshProUGUI GameInstructionNameText;
    [SerializeField] private Image GameInstructionImage;
    [SerializeField] private TextMeshProUGUI GameInstructionDescrptionTextBox;

    [SerializeField] private int currentIndex = 0;
    [SerializeField] private int maxIndex;

    private void Awake()
    {

    }

    private void Start()
    {
        //GameMangerRootMaster.instance.settingsManager.ActivePause(true, 0f);
        //activeHowToPlay(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameMangerRootMaster.instance.settingsManager.ActivePause(false, 1f);
    
        }

        if (mainWindowGameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (currentIndex <= maxIndex - 1 && currentIndex > 0)
                { 
                    currentIndex -= 1;

                    DisplayGameInstruction(gameInstructionList.gameInstructionDatas[currentIndex]);
                }
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (currentIndex >= 0 && currentIndex != maxIndex - 1)
                {
                    currentIndex += 1;

                    DisplayGameInstruction(gameInstructionList.gameInstructionDatas[currentIndex]);
                }
            }
        }
    }

    //private void activeHowToPlay(bool activeFlag)
    //{
    //    GameMangerRootMaster.instance.uIEvents.InvokeActiveFadeBackground(activeFlag);
    //    mainWindowGameObject.SetActive(activeFlag);

    //    currentIndex = 0;
    //    maxIndex = gameInstructionList.gameInstructionDatas.Count;

    //    DisplayGameInstruction(gameInstructionList.gameInstructionDatas[currentIndex]);
    //}

    private void DisplayGameInstruction(GameInstructionData gameInstructionData)
    {
        GameInstructionNameText.text = gameInstructionData.gameInstructionName;
        GameInstructionImage.sprite = gameInstructionData.image;
        GameInstructionDescrptionTextBox.text = gameInstructionData.description;
    }


    private void OnDestroy()
    {
  
    }

}