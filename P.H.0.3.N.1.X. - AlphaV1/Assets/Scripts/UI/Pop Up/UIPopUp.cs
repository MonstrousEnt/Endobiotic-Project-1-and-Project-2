/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 14, 2023
 * Last Updated: Match 12, 2023
 * Description: This is the UI class for pop up.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIPopUp : UIBase
{
    #region Class Variables
    [Header("UI Components")]
    [SerializeField] private TextMeshProUGUI m_messgesTextBox;
    [SerializeField] private GameObject m_yesButtonGameObject;
    [SerializeField] private GameObject m_NoButtonGameObject;
    [SerializeField] private GameObject m_popUpFirstButton;

    [Header("Pop Up Data")]
    [SerializeField] private PopUpDataScriptableObject m_popUpData;
    #endregion

    #region Setters and Getters
    public void SetPopUpData(PopUpDataScriptableObject popUpData)
    {
        this.m_popUpData = null;

        this.m_popUpData = popUpData;
    }
    #endregion

    #region Unity Methods
    private void Update()
    {
        //When the pop is ready to close, and if the user press any key, close the pop up.
        if (Input.anyKey)
        {
            if (m_popUpData != null)
            {
                if (m_popUpData.isReadyToClose)
                {
                    DisablePopUp();
                }
            }
        }
    }
    #endregion

    #region UI Pop Up Methods
    public void EnablePopUp()
    {
        displayPopUpData();
        EnableMainWindow();
    }

    public void DisablePopUp()
    {
        DisableMainWindow();
    }
    private void displayPopUpData()
    {
        if (m_popUpData != null)
        {
            cleanUIData();

            m_messgesTextBox.text = m_popUpData.message;

            if (m_popUpData.isConfirm)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(m_popUpFirstButton);

                m_yesButtonGameObject.SetActive(true);
                m_NoButtonGameObject.SetActive(true);
            }
        }
    }

    private void cleanUIData()
    {
        m_messgesTextBox.text = "";
        m_yesButtonGameObject.SetActive(false);
        m_NoButtonGameObject.SetActive(false);
    }

    public void YesActionPopUpOnClick()
    {
        if (m_popUpData != null)
        {
            m_popUpData.popUpActionUnityEvent?.Invoke();
        }
    }
    #endregion
}