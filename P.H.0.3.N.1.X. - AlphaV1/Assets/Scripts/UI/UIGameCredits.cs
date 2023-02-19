using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameCredits : MonoBehaviour
{
    [SerializeField] private GameObject mainWindowGameObject;

    [SerializeField] private Animator animator;

    [SerializeField] private float animtionTimer;

    private void Awake()
    {
        GameMangerRootMaster.instance.uIEvents.displayGameCreditsUnityEvent.AddListener(displayGameCredits);
    }

    private void Start()
    {
        //displayGameCredits();
    }

    private void OnDestroy()
    {
        GameMangerRootMaster.instance.uIEvents.displayGameCreditsUnityEvent.RemoveListener(displayGameCredits);
    }

    private void displayGameCredits()
    {
        StopCoroutine(gameCreditsAnimation());
        StartCoroutine(gameCreditsAnimation());
    }

    private IEnumerator gameCreditsAnimation()
    {
        //Enable Screen
        mainWindowGameObject.SetActive(true);

        //start animation
        animator.Play("GameCreditsScrolling");

        yield return new WaitForSeconds(animtionTimer);

        //close window
        mainWindowGameObject.SetActive(false);
    }
}
