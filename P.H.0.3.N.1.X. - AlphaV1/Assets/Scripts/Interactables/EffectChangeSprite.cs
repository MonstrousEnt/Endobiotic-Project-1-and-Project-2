using UnityEngine;

/// <summary>
/// This effect class is for changing sprites of any game object.
/// </summary>


[RequireComponent(typeof(SpriteRenderer))]
public class EffectChangeSprite : MonoBehaviour
{
    #region Class Variables
    [Header("Sprites")]
    [SerializeField] private Sprite m_defaultState;
    [SerializeField] private Sprite m_newState;

    //Components 
    private SpriteRenderer m_spriteRenderer;

    #endregion

    #region Unity Methods
    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        m_spriteRenderer.sprite = m_defaultState;
    }
    #endregion

    #region Sprite Changes Methods
    public void ChangeSprite()
    {
        m_spriteRenderer.sprite = m_newState;
    }
    #endregion
}
