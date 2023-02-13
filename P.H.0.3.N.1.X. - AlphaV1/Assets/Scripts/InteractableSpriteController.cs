using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class InteractableSpriteController : MonoBehaviour
{
    [SerializeField] Sprite isActiveSprite;
    [SerializeField] Sprite isInactiveSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(bool status)
    {
        if (status)
        {
            spriteRenderer.sprite = isActiveSprite;
        }
        else
        {
            spriteRenderer.sprite = isInactiveSprite;
        }
    }
}
