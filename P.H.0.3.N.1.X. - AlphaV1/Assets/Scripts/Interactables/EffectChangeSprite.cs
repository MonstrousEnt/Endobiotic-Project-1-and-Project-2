using UnityEngine;

/// <summary>
/// This effect class is for changing sprites of any game object.
/// </summary>


[RequireComponent(typeof(SpriteRenderer))]
public class EffectChangeSprite : MonoBehaviour
{
    #region Class Variables
    [Header("Sprites")]
    [SerializeField] private Sprite defaultState;
    [SerializeField] private Sprite newState;

    //Components 
    private SpriteRenderer spriteRenderer;

    #endregion

    #region Unity Methods
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = defaultState;
    }
    #endregion

    #region Sprite Changes Methods
    public void ChangeSprite()
    {
        spriteRenderer.sprite = newState;
    }
    #endregion
}
