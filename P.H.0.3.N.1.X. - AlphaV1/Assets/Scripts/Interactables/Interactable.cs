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

        SubscribeToPrerequisites();

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
        if (CheckIfPrerequisitesMet())
        {
            isInteractable = true;
            UpdateSprite();
        }
        else
        {
            isInteractable = false;
            UpdateSprite();
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
    /// <summary>
    /// Interact with the object if there is interaction.
    /// </summary>
    /// <param name="currForm"></param>
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

        UpdateSprite();
    }

    public void Reenable()
    {
        hasInteracted = false;
        UpdateSprite();
    }

    /// <summary>
    /// Update the sprite.
    /// </summary>
    private void UpdateSprite()
    {
        interactableSpriteController.ChangeSprite(isInteractable, hasInteracted);
    }

    /// <summary>
    /// Check to see if the prerequisite were met or not.
    /// </summary>
    /// <returns></returns>
    private bool CheckIfPrerequisitesMet()
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

    /// <summary>
    /// Subscribe to Prerequisites Unity Events
    /// </summary>
    private void SubscribeToPrerequisites()
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
