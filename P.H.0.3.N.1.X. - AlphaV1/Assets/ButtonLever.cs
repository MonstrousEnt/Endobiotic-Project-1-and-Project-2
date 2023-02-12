using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLever : MonoBehaviour
{
    [SerializeField] private Image buttonLeverImage;

    [SerializeField] private Sprite buttonLeverSprite;

    [SerializeField] private GameObject DoorGameObject;

    public void AcvtiveButtonLever()
    {
        //button do something
        DoorGameObject.SetActive(false);
    }
}
