using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterFormsController : MonoBehaviour
{
    /// <summary>
    /// Controls which form the character is currently is and allows for switching forms
    /// </summary>

    public Form currForm { get; private set; }
    public Sprite[] formSprites;
    public Color[] formColours;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Init();
    }

    public void KillForm()
    {
        int numForms = Enum.GetNames(typeof(Form)).Length;
        int currFormNum = (int)currForm;
        int nextFormInt = (currFormNum + 1) % numForms;        

        ChangeForm(nextFormInt);
    }

    private void Init()
    {
        ChangeForm(0);        
    }

    private void ChangeForm(int newFormInt)
    {
        currForm = (Form)newFormInt;
        spriteRenderer.color = formColours[newFormInt];
    }


    //private void ChangeForm(int newFormInt)
    //{
    //    currForm = (Form)newFormInt;
    //    spriteRenderer.sprite = formSprites[newFormInt];
    //}    
}