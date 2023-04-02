/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 12, 2023
 * Last Updated: Match 30, 2023
 * Description: This class is for all game object intractables.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InteractableSpriteController))]
public class Interactable : MonoBehaviour, IPrerequisite
{
    #region Class Variables
    [Header("Required Form")]
    [SerializeField] private Form m_requiredForm = Form.manipulator;

    [Header("Unity Events")]
    [SerializeField] private UnityEvent m_onActivated;

    [Header("Lists")]
    [SerializeField] private List<Interactable> m_prerequisites;

    //Intractable
    private bool m_isInteractable;
    private bool m_hasInteracted;
    private InteractableSpriteController m_interactableSpriteController;
    #endregion

    #region Getters and Setters
    public void SetPrerequisiteComplete()
    {
        checkSetActive();
    }

    private void checkSetActive()
    {
        if (checkIfPrerequisitesMet())
        {
            m_isInteractable = true;
            updateSprite();
        }
        else
        {
            m_isInteractable = false;
            updateSprite();
        }
    }
    #endregion

    #region Interface Methods
    public bool IsComplete()
    {
        return m_hasInteracted;
    }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        m_interactableSpriteController = GetComponent<InteractableSpriteController>();
    }

    private void Start()
    {
        if(m_onActivated == null)
        {
            m_onActivated = new UnityEvent();
        }

        m_hasInteracted = false;        

        subscribeToPrerequisites();

        checkSetActive();
    }
    #endregion

    #region Intractable Methods
    public void Interact(Form a_currForm)
    {
        if (!m_isInteractable)
        {
            return;
        }

        if (a_currForm != m_requiredForm || m_hasInteracted == true)
        {
            return;
        }

        m_hasInteracted = true;

        if (m_onActivated != null)
        {
            m_onActivated?.Invoke();
        }

        updateSprite();
    }

    public void Reenable()
    {
        m_hasInteracted = false;
        updateSprite();
    }

    private void updateSprite()
    {
        m_interactableSpriteController.ChangeSprite(m_isInteractable, m_hasInteracted);
    }

    private bool checkIfPrerequisitesMet()
    {
        if(m_prerequisites.Count <= 0)
        {
            return true;
        }
        else
        {
            bool l_returnValue = true;

            for (int i = 0; i < m_prerequisites.Count; i++)
            {
                if (!m_prerequisites[i].IsComplete())
                {
                    l_returnValue = false;
                }
            }

            return l_returnValue;
        }
    }    

    private void subscribeToPrerequisites()
    {
        if(m_prerequisites.Count > 0)
        {
            for (int i = 0; i < m_prerequisites.Count; i++)
            {
                m_prerequisites[i].m_onActivated.AddListener(SetPrerequisiteComplete);
            }
        }
    }
    #endregion
}
