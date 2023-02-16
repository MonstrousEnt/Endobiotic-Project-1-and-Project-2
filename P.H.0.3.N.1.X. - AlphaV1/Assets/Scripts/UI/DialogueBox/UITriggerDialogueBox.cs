using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITriggerDialogueBox : MonoBehaviour
{
    [SerializeField] private DialogueData dialogueData;

    private void triggerDialogueBox()
    {
        GameMangerRootMaster.instance.uIEvents.InvokeSetDialogueDataUnityEvent(dialogueData);
        GameMangerRootMaster.instance.uIEvents.InvokeActiveDialogueBoxUnityEvent(true);
    }

    private void Update()
    {
       if( Input.GetKeyDown(KeyCode.G))
       {
            triggerDialogueBox();
       }
    }
}
