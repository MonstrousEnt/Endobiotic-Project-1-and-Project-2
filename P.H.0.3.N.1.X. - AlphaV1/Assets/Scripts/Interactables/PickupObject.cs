using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PickupObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Interactable interactable;
    private CharacterItemHolder characterItemHolder;
    private Sprite itemSprite;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactable = GetComponent<Interactable>();
        characterItemHolder = FindObjectOfType<CharacterItemHolder>();
    }

    private void Start()
    {
        itemSprite = spriteRenderer.sprite;
    }

    public void PickupItem()
    {
        characterItemHolder.AddItem(this, itemSprite);
    }

    public void ReturnItem()
    {
        interactable.Reenable();
    }
}
