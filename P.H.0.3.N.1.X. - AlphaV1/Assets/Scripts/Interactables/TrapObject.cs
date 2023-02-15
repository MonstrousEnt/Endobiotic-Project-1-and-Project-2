using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class TrapObject : MonoBehaviour
{
    [SerializeField] private InteractableOjbects objectType;
    [SerializeField] private Sprite hasActivatedSprite;

    private SpriteRenderer spriteRenderer;
    private Collider2D trapCollider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trapCollider = GetComponent<Collider2D>();
    }

    public void Interact()
    {
        spriteRenderer.sprite = hasActivatedSprite;
        trapCollider.enabled = false;
    }

    public InteractableOjbects GetObjectType()
    {
        return objectType;
    }
}
