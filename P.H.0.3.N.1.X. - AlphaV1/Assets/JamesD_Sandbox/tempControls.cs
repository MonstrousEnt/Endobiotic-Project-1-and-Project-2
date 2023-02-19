using UnityEngine;

[RequireComponent(typeof(CharacterFormsController))]
public class tempControls : MonoBehaviour
{
    private CharacterFormsController cfc;

    // Start is called before the first frame update
    void Start()
    {
        cfc = GetComponent<CharacterFormsController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //cfc.KillForm();
        }
    }
}
