using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIDialogueBox : MonoBehaviour
{
    [SerializeField] private GameObject mainWindowGameObject;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image portraitImage;
    [SerializeField] private TextMeshProUGUI messageTextBox;

    [SerializeField] private bool activeSubmit = false;

    [SerializeField] private DialogueData dialogueData;

    [SerializeField] private Queue<string> messages;

    private void Awake()
    {
        //GameMangerRootMaster.instance.uIEvents.setDialogueDataUnityEvent.AddListener(setDialogueData);
        //GameMangerRootMaster.instance.uIEvents.activeDialogueBoxUnityEvent.AddListener(activeDialogueBox);
    }

    private void Update()
    {
        if (mainWindowGameObject.activeSelf)
        {
            //If the submit button is active
            if (activeSubmit)
            {
                //When the user press E (test)
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Go to the next sentence in the dialogue
                    displayNextMessage();

                    activeSubmit = false;
                }
            }
        }
    }

    private void OnDestroy()
    {
        //GameMangerRootMaster.instance.uIEvents.setDialogueDataUnityEvent.RemoveListener(setDialogueData);
       //GameMangerRootMaster.instance.uIEvents.activeDialogueBoxUnityEvent.RemoveListener(activeDialogueBox);
    }

    private void setDialogueData(DialogueData dialogueData)
    {
        this.dialogueData = null;

        this.dialogueData = dialogueData;
    }


    private void activeDialogueBox(bool activeFlag)
    {
        //GameMangerRootMaster.instance.playerManager.DisableCharacterControls();

        mainWindowGameObject.SetActive(activeFlag);

        if (dialogueData != null)
        {
            displayDiagloueBoxData();
        }
    }

    private void cleanAllUIData()
    {
        nameText.text = "";
        portraitImage.sprite = null;

        messages = new Queue<string>();
        messages.Clear();

        activeSubmit = false;

        cleanNessageUIData();
    }

    private void cleanNessageUIData()
    {
        messageTextBox.text = "";
    }

    private void displayDiagloueBoxData()
    {
        cleanAllUIData();

        nameText.text = dialogueData.dialogueName;
        portraitImage.sprite = dialogueData.portraitSprite;

        for (int i = 0; i < dialogueData.messages.Count; i++)
        {
            messages.Enqueue(dialogueData.messages[i]);
        }

        displayNextMessage();
    }

    private void displayNextMessage()
    {
        //If there no message left
        if (messages.Count == 0)
        {
            //End the dialogue 
            endDialogue();

            //Exit out the method
            return;
        }

        //Get the next one in the queue
        string message = messages.Dequeue();

        //Animate the UI message text
        StopAllCoroutines();
        StartCoroutine(typeSentence(message));
    }

    private IEnumerator typeSentence(string message)
    {
        cleanNessageUIData();

        //Add each char to the dialogue
        foreach (char letter in message.ToCharArray())
        {
            messageTextBox.text += letter;
            yield return null;
        }

        //Turn on the submit button
        activeSubmit = true;
    }

    private void endDialogue()
    {
        mainWindowGameObject.SetActive(false);

        //GameMangerRootMaster.instance.playerManager.EnableCharacterControls();
    }
}
