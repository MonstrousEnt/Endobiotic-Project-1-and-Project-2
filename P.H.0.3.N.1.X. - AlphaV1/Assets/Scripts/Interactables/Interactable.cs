using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InteractableSpriteController))]
public class Interactable : MonoBehaviour, IPrerequisite
{
    #region Class Variables
    [Header("Required Form")]
    [SerializeField] private Form m_requiredForm = Form.Manipulator;

    [Header("Unity Events")]
    [SerializeField] private UnityEvent m_onActivated;

    [Header("Lists")]
    [SerializeField] private List<Interactable> m_prerequisites;

    //Intractable
    private bool m_isInteractable;
    private bool m_hasInteracted;
    private InteractableSpriteController m_interactableSpriteController;
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

        CheckSetActive();
    }
    #endregion

    #region Getters and Setters
    public void SetPrerequisiteComplete()
    {
        CheckSetActive();
    }

    private void CheckSetActive()
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

    #region Intractable Methods
    public void Interact(Form currForm)
    {
        if (!m_isInteractable)
        {
            return;
        }

        if (currForm != m_requiredForm || m_hasInteracted == true)
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
            bool returnValue = true;

            for (int i = 0; i < m_prerequisites.Count; i++)
            {
                if (!m_prerequisites[i].IsComplete())
                {
                    returnValue = false;
                }
            }

            return returnValue;
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
