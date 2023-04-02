/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 13, 2023
 * Last Updated: April 2, 2023
 * Description: This is the class for the player holding any item.
 * Notes: 
 * Resources: 
 *  
 */

using UnityEngine;

public class CharacterItemHolder : MonoBehaviour
{
    #region Class Variables 
    //Intractable  
    [Header("Sprite")]
    [SerializeField] private SpriteRenderer m_itemSpriteRenderer;

    //Intractable
    private EffectPickupItem m_currentPickupObject;
    #endregion

    #region Unity Methods
    private void Start()
    {
        m_itemSpriteRenderer.sprite = null;
    }
    #endregion

    #region Item Holder Methods
    public void AddItem(EffectPickupItem a_pickupItem, Sprite a_itemSprite)
    {
        m_currentPickupObject = a_pickupItem;
        m_itemSpriteRenderer.sprite = a_itemSprite;
    }

    public void DropItem()
    {
        if(m_currentPickupObject == null)
        {
            return;
        }

        m_currentPickupObject.ReturnItem();
        m_currentPickupObject = null;

        m_itemSpriteRenderer.sprite = null;
    }

    public void UseItem()
    {
        if (m_currentPickupObject == null)
        {
            return;
        }

        m_currentPickupObject = null;
        m_itemSpriteRenderer.sprite = null;
    }
    #endregion
}
