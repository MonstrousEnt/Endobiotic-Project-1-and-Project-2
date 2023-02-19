using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class InteractableSpriteController : MonoBehaviour
{
    [SerializeField] private bool useInteractableSpriteController = true;

    [SerializeField] Sprite nonInteractableSprite;
    [SerializeField] Sprite isInteractableSprite;
    [SerializeField] Sprite hasInteractedSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (useInteractableSpriteController)
            DisableAnimatorIfNeeded();
    }

    public void ChangeSprite(bool isActive, bool hasActivated)
    {
        if (!useInteractableSpriteController)
            return;

        if (hasActivated)
        {
            spriteRenderer.sprite = hasInteractedSprite;
        }
        else if(isActive)
        {
            spriteRenderer.sprite = isInteractableSprite;
        }
        else
        {
            spriteRenderer.sprite = nonInteractableSprite;
        }
    }

    private void DisableAnimatorIfNeeded()
    {
        if(TryGetComponent(out Animator animator))
        {
            if (animator.isActiveAndEnabled)
                animator.enabled = false;
        }
    }
}
