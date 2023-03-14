using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EffectPickupItem : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Interactable interactable;
    private CharacterItemHolder characterItemHolder;

    private void Awake()
    {
        //Initialize components 
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactable = GetComponent<Interactable>();
        characterItemHolder = FindObjectOfType<CharacterItemHolder>(); //Hold reference, this could be a Singleton or direct input form a game event
    }

    /// <summary>
    /// Player pick up the item 
    /// </summary>
    public void PickupItem()
    {        
        characterItemHolder.AddItem(this, spriteRenderer.sprite);
    }


    public void ReturnItem()
    {
        interactable.Reenable();
    }
}
