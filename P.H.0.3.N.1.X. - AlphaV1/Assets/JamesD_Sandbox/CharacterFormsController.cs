using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFormsController : MonoBehaviour
{
    /// <summary>
    /// Controls which form the character is currently is and allows for switching forms
    /// </summary>

    public Form currForm { get; private set; }

    private void Start()
    {
        Init();
    }

    public void KillForm()
    {

    }

    private void Init()
    {
        currForm = Form.Manipulator;
    }

    private void ChangeForm(Form newForm)
    {
        currForm = newForm;
    }
}