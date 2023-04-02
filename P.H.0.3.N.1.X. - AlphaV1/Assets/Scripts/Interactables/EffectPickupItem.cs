/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 13, 2023
 * Last Updated: April 2, 2023
 * Description: This effect class is for up item of any game object.
 * Notes: 
 * Resources: 
 *  
 */

using UnityEngine;

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
