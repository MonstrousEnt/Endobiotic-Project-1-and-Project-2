using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLever : MonoBehaviour
{
    [SerializeField] private Image buttonLeverImage;

    [SerializeField] private Sprite buttonLeverSprite;

    [SerializeField] private GameObject DoorGameObject;

    [SerializeField] private GameObject UIButtonLeverMenu;

    public void AcvtiveButtonLever()
    {
        StopCoroutine(RunButtonLever());
        StartCoroutine(RunButtonLever());
    }

    private IEnumerator RunButtonLever()
    {
        //button do something
        DoorGameObject.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        UIButtonLeverMenu.SetActive(false);
    }
}
