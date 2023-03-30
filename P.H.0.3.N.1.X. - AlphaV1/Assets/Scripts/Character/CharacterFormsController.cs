/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 13, 2023
 * Last Updated: Match 29, 2023
 * Description: Controls which form the character is currently is and allows for switching forms.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections.Generic;
using UnityEngine;

public class CharacterFormsController : MonoBehaviour
{
    #region Class Variables
    [Header("Player Forms (Game Objects)")]
    [SerializeField] private List<GameObject> m_formObjects;

    //Components
    private BaseControllerAnimations m_controllerAnimations;

    //Player Current form
    private Form m_currform;

    #endregion

    #region Getters and Setters
    public Form currForm { get { return m_currform; } private set { m_currform = value; } }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        m_controllerAnimations = GetComponent<BaseControllerAnimations>();
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

        foreach (GameObject formObject in m_formObjects)
        {
            formObject.SetActive(false);
        }

        m_formObjects[(int)newForm].SetActive(true);

        m_controllerAnimations.Animator = m_formObjects[(int)newForm].GetComponent<Animator>();
    }
    #endregion
}