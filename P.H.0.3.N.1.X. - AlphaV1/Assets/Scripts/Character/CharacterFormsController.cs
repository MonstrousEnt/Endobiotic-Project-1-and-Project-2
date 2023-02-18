using UnityEngine;

public class CharacterFormsController : MonoBehaviour
{
    /// <summary>
    /// Controls which form the character is currently is and allows for switching forms
    /// </summary>

    public Form currForm { get; private set; }
    public Color[] formColours;
    [SerializeField] private GameObject[] formObjects;

    private BaseControllerAnimations controllerAnimations;

    private void Awake()
    {
        controllerAnimations = GetComponent<BaseControllerAnimations>();
        Init();
    }

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
        formObjects[(int)newForm].GetComponent<SpriteRenderer>().color = formColours[(int)newForm];

        controllerAnimations.SetAnimator(formObjects[(int)newForm].GetComponent<Animator>());
    } 
}