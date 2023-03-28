using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InteractableSpriteController))]
public class Interactable : MonoBehaviour, IPrerequisite
{
    #region Class Variables
    [Header("Required Form")]
    [SerializeField] private Form requiredForm = Form.Manipulator;

    [Header("Unity Events")]
    [SerializeField] private UnityEvent onActivated;

    [Header("Lists")]
    [SerializeField] private Interactable[] prerequisites;

    //Intractable
    private bool isInteractable;
    private bool hasInteracted;
    private InteractableSpriteController interactableSpriteController;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        interactableSpriteController = GetComponent<InteractableSpriteController>();
    }

    private void Start()
    {
        if(onActivated == null)
        {
            onActivated = new UnityEvent();
        }

        hasInteracted = false;        

        subscribeToPrerequisites();

        CheckSetActive();
    }
    #endregion

    #region Getters and Setters
    public void SetPrerequisiteComplete()
    {
        CheckSetActive();
    }

    private void CheckSetActive()
    {
        if (checkIfPrerequisitesMet())
        {
            isInteractable = true;
            updateSprite();
        }
        else
        {
            isInteractable = false;
            updateSprite();
        }
    }
    #endregion

    #region Interface Methods
    public bool IsComplete()
    {
        return hasInteracted;
    }
    #endregion

    #region Intractable Methods
    public void Interact(Form currForm)
    {
        if (!isInteractable)
        {
            return;
        }

        if (currForm != requiredForm || hasInteracted == true)
        {
            return;
        }

        hasInteracted = true;

        if (onActivated != null)
        {
            onActivated.Invoke();
        }

        updateSprite();
    }

    public void Reenable()
    {
        hasInteracted = false;
        updateSprite();
    }

    private void updateSprite()
    {
        interactableSpriteController.ChangeSprite(isInteractable, hasInteracted);
    }

    private bool checkIfPrerequisitesMet()
    {
        if(prerequisites.Length <= 0)
        {
            return true;
        }
        else
        {
            bool returnValue = true;

            for (int i = 0; i < prerequisites.Length; i++)
            {
                if (!prerequisites[i].IsComplete())
                {
                    returnValue = false;
                }
            }

            return returnValue;
        }
    }    

    private void subscribeToPrerequisites()
    {
        if(prerequisites.Length > 0)
        {
            for (int i = 0; i < prerequisites.Length; i++)
            {
                prerequisites[i].onActivated.AddListener(SetPrerequisiteComplete);
            }
        }
    }
    #endregion
}
