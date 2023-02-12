using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButtonLeverMneu : MonoBehaviour
{
    [SerializeField] private GameObject UIMenuButtonLever;

   

    private void Start()
    {
        UIMenuButtonLever.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            UIMenuButtonLever.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CharacterFormsController player = collision.collider.GetComponent<CharacterFormsController>();

        if (player.currForm == Form.Manipulator)
        {
            UIMenuButtonLever.SetActive(true);
        }
    }
}
