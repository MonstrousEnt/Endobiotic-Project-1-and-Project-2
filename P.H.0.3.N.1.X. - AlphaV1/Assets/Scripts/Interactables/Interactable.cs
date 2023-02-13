using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InteractableSpriteController))]
public class Interactable : MonoBehaviour
{
    [SerializeField] private Form requiredForm = Form.Manipulator;
    [SerializeField] private bool isInteractable = true;

    private bool hasActivated;
    private InteractableSpriteController interactableSpriteController;

    public UnityEvent onActivated;

    private void Start()
    {
        if(onActivated == null)
        {
            onActivated = new UnityEvent();
        }

        hasActivated = false;

        interactableSpriteController = GetComponent<InteractableSpriteController>();
        interactableSpriteController.ChangeSprite(isInteractable && !hasActivated);
    }

    public void Interact(Form currForm)
    {
        if (!isInteractable)
        {
            return;
        }

        if (currForm != requiredForm || hasActivated == true)
        {
            return;
        }

        hasActivated = true;
        interactableSpriteController.ChangeSprite(isInteractable && !hasActivated);

        if (onActivated != null)
        {
            onActivated.Invoke();
        }
    }

    public void SetActive()
    {
        isInteractable = true;
        interactableSpriteController.ChangeSprite(isInteractable && !hasActivated);
    }
}
