using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EffectPickupItem : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Interactable interactable;
    private CharacterItemHolder characterItemHolder;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactable = GetComponent<Interactable>();
        characterItemHolder = FindObjectOfType<CharacterItemHolder>();
    }

    public void PickupItem()
    {        
        characterItemHolder.AddItem(this, spriteRenderer.sprite);
    }

    public void ReturnItem()
    {
        interactable.Reenable();
    }
}
