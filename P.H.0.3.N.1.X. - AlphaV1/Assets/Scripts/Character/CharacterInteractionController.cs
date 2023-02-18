using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterFormsController))]
public class CharacterInteractionController : MonoBehaviour
{
    private CharacterFormsController characterFormsController;
    private CharacterItemHolder characterItemHolder;
    private List<Interactable> currentlyInteractable;

    [SerializeField] private GameObject deathPrefab;
    [SerializeField] private ParticleSystem riseAgainParticles;

    private void Awake()
    {
        characterFormsController = GetComponent<CharacterFormsController>();
        characterItemHolder = GetComponent<CharacterItemHolder>();
    }

    private void Start()
    {
        currentlyInteractable = new List<Interactable>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") && collision.collider.GetComponent<CharacterFormsController>().currForm == Form.Enemy && characterFormsController.currForm == Form.Destroyer)
        {
            return;
        }
        else if (collision.collider.CompareTag("Enemy") && collision.collider.GetComponent<CharacterFormsController>().currForm == Form.Enemy)
        {
            Respawn();
        }
        else if (collision.collider.CompareTag("Enemy") && characterFormsController.currForm != collision.collider.GetComponent<CharacterFormsController>().currForm)
        {
            RespawnAsNewForm(collision.collider.GetComponent<CharacterFormsController>().currForm, collision.collider.transform.position);
            collision.collider.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable") || collision.CompareTag("Enemy"))
        {
            if(collision.TryGetComponent(out Interactable interactable))
            {
                currentlyInteractable.Add(interactable);
            }
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interactable interactable))
        {
            currentlyInteractable.Remove(interactable);
        }
    }

    private void Respawn()
    {
        //characterFormsController.KillForm();
        characterItemHolder.DropItem();

        // TODO set a respawn location or enable a variable for a designer
        Vector2 randomLocation = new Vector2(Random.Range(-4.0f, 4.0f), Random.Range(-2.0f, 2.0f));
        transform.position = new Vector3(randomLocation.x, randomLocation.y, 0);
    }

    private void RespawnAsNewForm(Form newForm, Vector3 position)
    {
        GameMangerRootMaster.instance.playerManager.DisableCharacterControls();
        GameObject deathInstance = Instantiate(deathPrefab, transform.position, Quaternion.identity);
        deathInstance.GetComponent<CharacterFormsController>().ChangeForm(characterFormsController.currForm);  // These were firing before Start() on deathInstance.  Weird.
        deathInstance.GetComponent<CharacterDeathController>().Die();
        riseAgainParticles.Play();
        characterFormsController.ChangeForm(newForm);
        transform.position = position;
        StartCoroutine(WaitWhileDead(2));
    }

    public void Interact()
    {
        if(currentlyInteractable.Count <= 0)
        {
            return;
        }

        foreach(Interactable interactable in currentlyInteractable)
        {
            interactable.Interact(characterFormsController.currForm);
        }
    }

    private IEnumerator WaitWhileDead(float duration)
    {
        yield return new WaitForSeconds(duration);
        GameMangerRootMaster.instance.playerManager.EnableCharacterControls();
    }
}
