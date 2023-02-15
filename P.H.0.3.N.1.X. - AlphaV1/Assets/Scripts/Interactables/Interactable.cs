using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InteractableSpriteController))]
public class Interactable : MonoBehaviour, IPrerequisite
{
    [SerializeField] private Form requiredForm = Form.Manipulator;

    private bool isInteractable;
    private bool hasInteracted;
    private InteractableSpriteController interactableSpriteController;

    public UnityEvent onActivated;
    public Interactable[] prerequisites;

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

        SubscriteToPrerequisites();

        CheckSetActive();
    }

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
        UpdateSprite();

        if (onActivated != null)
        {
            onActivated.Invoke();
        }
    }
    public bool IsComplete()
    {
        return hasInteracted;
    }

    public void SetPrerequisiteComplete()
    {
        CheckSetActive();
    }

    public void Reenable()
    {
        hasInteracted = false;
        UpdateSprite();
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

    private void UpdateSprite()
    {
        interactableSpriteController.ChangeSprite(isInteractable, hasInteracted);
    }

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

    private void SubscriteToPrerequisites()
    {
        if(prerequisites.Length > 0)
        {
            for (int i = 0; i < prerequisites.Length; i++)
            {
                prerequisites[i].onActivated.AddListener(SetPrerequisiteComplete);
            }
        }
    }
}
