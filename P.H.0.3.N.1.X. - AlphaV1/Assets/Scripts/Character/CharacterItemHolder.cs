using UnityEngine;

public class CharacterItemHolder : MonoBehaviour
{
    private PickupObject m_currentPickupObject;
    [SerializeField] private SpriteRenderer m_itemSpriteRenderer;

    private void Start()
    {
        m_itemSpriteRenderer.sprite = null;
    }

    public void AddItem(PickupObject pickupObject, Sprite itemSprite)
    {
        m_currentPickupObject = pickupObject;
        m_itemSpriteRenderer.sprite = itemSprite;
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
}
