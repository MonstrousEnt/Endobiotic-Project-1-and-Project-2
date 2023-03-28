using UnityEngine;


/// <summary>
/// This effect class is for up item of any game object.
/// </summary>

[RequireComponent(typeof(SpriteRenderer))]
public class EffectPickupItem : MonoBehaviour
{
    #region Class Variables
    [Header("Tag Scriptable Object")]
    [SerializeField] private TagDataScriptableObject tagDataPlayer;

    //Components
    private SpriteRenderer spriteRenderer;
    private Interactable interactable;
    private CharacterItemHolder characterItemHolder;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactable = GetComponent<Interactable>();

        characterItemHolder = GameObject.FindGameObjectWithTag(tagDataPlayer.tagName).GetComponent<CharacterItemHolder>();  
    }
    #endregion

    #region Items Methods
    public void PickupItem()
    {        
        characterItemHolder.AddItem(this, spriteRenderer.sprite);
    }

    public void ReturnItem()
    {
        interactable.Reenable();
    }
    #endregion
}
