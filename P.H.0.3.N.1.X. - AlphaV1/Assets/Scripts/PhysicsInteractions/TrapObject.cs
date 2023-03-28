using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class TrapObject : MonoBehaviour
{
    #region Class Variables
    [Header("Intractable")]
    [SerializeField] private InteractableOjbects objectType;

    [Header("Sprite")]
    [SerializeField] private Sprite hasActivatedSprite;
    private SpriteRenderer spriteRenderer;

    [Header("Unity Events")]
    [SerializeField] private UnityEvent m_addPointUnityEvent;

    //Trap
    private Collider2D trapCollider;

    #endregion

    #region Unity Methods 
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trapCollider = GetComponent<Collider2D>();
    }
    #endregion

    #region Intractable Methods
    public void Interact()
    {
        spriteRenderer.sprite = hasActivatedSprite;
        trapCollider.enabled = false;

        m_addPointUnityEvent?.Invoke();
    }

    public InteractableOjbects GetObjectType()
    {
        return objectType;
    }

    #endregion
}
