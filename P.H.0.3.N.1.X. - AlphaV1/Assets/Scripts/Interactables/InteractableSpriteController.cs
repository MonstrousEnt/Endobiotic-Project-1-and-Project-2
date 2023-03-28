using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class InteractableSpriteController : MonoBehaviour
{
    [Header("Intractable Boolean Flag for Sprite")]
    [SerializeField] private bool useInteractableSpriteController = true;

    [Header("Intractable Sprite")]
    [SerializeField] Sprite nonInteractableSprite;
    [SerializeField] Sprite isInteractableSprite;
    [SerializeField] Sprite hasInteractedSprite;

    //Components
    private SpriteRenderer spriteRenderer;

    #region Unity Methods
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (useInteractableSpriteController)
        {
            disableAnimatorIfNeeded();
        }
    }
    #endregion

    #region Sprite Methods
    public void ChangeSprite(bool isActive, bool hasActivated)
    {
        if (!useInteractableSpriteController)
        {
            return;
        }

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
    #endregion

    #region Animation Methods
    private void disableAnimatorIfNeeded()
    {
        if(TryGetComponent(out Animator animator))
        {
            if (animator.isActiveAndEnabled)
                animator.enabled = false;
        }
    }
    #endregion
}
