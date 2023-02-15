using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class InteractableSpriteController : MonoBehaviour
{
    [SerializeField] Sprite nonInteractableSprite;
    [SerializeField] Sprite isInteractableSprite;
    [SerializeField] Sprite hasInteractedSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(bool isActive, bool hasActivated)
    {
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
}
