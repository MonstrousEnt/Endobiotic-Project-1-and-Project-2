using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class TrapObject : MonoBehaviour
{
    #region Class Variables
    [Header("Intractable")]
    [SerializeField] private InteractableOjbects m_objectType;

    [Header("Sprite")]
    [SerializeField] private Sprite m_hasActivatedSprite;


    [Header("Unity Events")]
    [SerializeField] private UnityEvent m_addPointUnityEvent;

    //Sprite
    private SpriteRenderer m_spriteRenderer;

    //Trap
    private Collider2D m_trapCollider;


    #endregion

    #region Unity Methods 
    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_trapCollider = GetComponent<Collider2D>();
    }
    #endregion

    #region Intractable Methods
    public void Interact()
    {
        m_spriteRenderer.sprite = m_hasActivatedSprite;
        m_trapCollider.enabled = false;

        m_addPointUnityEvent?.Invoke();
    }

    public InteractableOjbects GetObjectType()
    {
        return m_objectType;
    }

    #endregion
}
