/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 12, 2023
 * Last Updated: April 2, 2023
 * Description: This class is for intractable sprite.
 * Notes: 
 * Resources: 
 *  
 */

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class InteractableSpriteController : MonoBehaviour
{
    [Header("Intractable Boolean Flag for Sprite")]
    [SerializeField] private bool m_useInteractableSpriteController = true;

    [Header("Intractable Sprite")]
    [SerializeField] private Sprite m_nonInteractableSprite;
    [SerializeField] private Sprite m_isInteractableSprite;
    [SerializeField] private Sprite m_hasInteractedSprite;

    //Components
    private SpriteRenderer m_spriteRenderer;

    #region Unity Methods
    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (m_useInteractableSpriteController)
        {
            disableAnimatorIfNeeded();
        }
    }
    #endregion

    #region Sprite Methods
    public void ChangeSprite(bool a_isActive, bool a_hasActivated)
    {
        if (!m_useInteractableSpriteController)
        {
            return;
        }

        if (a_hasActivated)
        {
            m_spriteRenderer.sprite = m_hasInteractedSprite;
        }
        else if(a_isActive)
        {
            m_spriteRenderer.sprite = m_isInteractableSprite;
        }
        else
        {
            m_spriteRenderer.sprite = m_nonInteractableSprite;
        }
    }
    #endregion

    #region Animation Methods
    private void disableAnimatorIfNeeded()
    {
        if(TryGetComponent(out Animator a_animator))
        {
            if (a_animator.isActiveAndEnabled)
                a_animator.enabled = false;
        }
    }
    #endregion
}
