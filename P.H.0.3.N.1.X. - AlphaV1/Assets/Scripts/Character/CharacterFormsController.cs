using System.Collections.Generic;
using UnityEngine;

public class CharacterFormsController : MonoBehaviour
{
    /// <summary>
    /// Controls which form the character is currently is and allows for switching forms
    /// </summary>

    #region Class Variables
    [Header("Player Forms (Game Objects)")]
    [SerializeField] private List<GameObject> formObjects;

    //Components
    private BaseControllerAnimations controllerAnimations;

    //Player Current form
    private Form m_currform;

    #endregion

    #region Getters and Setters
    public Form currForm { get { return m_currform; } private set { m_currform = value; } }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        controllerAnimations = GetComponent<BaseControllerAnimations>();
        Init();
    }
    #endregion

    #region Character Form Methods
    private void Init()
    {
        ChangeForm(0);        
    }

    public void ChangeForm(Form newForm)
    {
        currForm = newForm;

        foreach (GameObject formObject in formObjects)
        {
            formObject.SetActive(false);
        }

        formObjects[(int)newForm].SetActive(true);

        controllerAnimations.Animator = formObjects[(int)newForm].GetComponent<Animator>();
    }
    #endregion
}