using UnityEngine;


/// <summary>
/// This effect class is for up item of any game object.
/// </summary>

[RequireComponent(typeof(SpriteRenderer))]
public class EffectPickupItem : MonoBehaviour
{
    #region Class Variables
    [Header("Tag Scriptable Object")]
    [SerializeField] private TagDataScriptableObject m_tagDataPlayer;

    //Components
    private SpriteRenderer m_spriteRenderer;
    private Interactable m_interactable;
    private CharacterItemHolder m_characterItemHolder;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_interactable = GetComponent<Interactable>();

        m_characterItemHolder = GameObject.FindGameObjectWithTag(m_tagDataPlayer.tagName).GetComponent<CharacterItemHolder>();  
    }
    #endregion

    #region Items Methods
    public void PickupItem()
    {        
        m_characterItemHolder.AddItem(this, m_spriteRenderer.sprite);
    }

    public void ReturnItem()
    {
        m_interactable.Reenable();
    }
    #endregion
}
