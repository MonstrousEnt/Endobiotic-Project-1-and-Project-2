using System.Collections.Generic;
using UnityEngine;

public class CharacterFormsController : MonoBehaviour
{
    /// <summary>
    /// Controls which form the character is currently is and allows for switching forms
    /// </summary>

    #region Class Variables
    //Player Current form
    private Form m_currform;

    [Header("List of player forms (Game Objects)")]
    [SerializeField] private List<GameObject> formObjects;

    //Reference to base animation controller 
    private BaseControllerAnimations controllerAnimations;
    #endregion

    #region Getters and Setters
    public Form currForm { get { return m_currform; } private set { m_currform = value; } }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        //Initialize components 
        controllerAnimations = GetComponent<BaseControllerAnimations>();

        //Initialize the default form
        Init();
    }
    #endregion

    #region C# Methods
    private void Init()
    {
        //Set the default from as Manipulator
        ChangeForm(0);        
    }

    public void ChangeForm(Form newForm)
    {
        //Set the current form to the new form
        currForm = newForm;

        //Turn off the previews form
        foreach (GameObject formObject in formObjects)
        {
            formObject.SetActive(false);
        }

        //Turn on the new form
        formObjects[(int)newForm].SetActive(true);

        //Change animator to the new form
        controllerAnimations.Animator = formObjects[(int)newForm].GetComponent<Animator>();
    }
    #endregion
}