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
    [SerializeField] private SoundData soundDataPlayerDeath;

    [SerializeField] private float invulTime = 1f;
    private float invulTimer;

    [SerializeField] private TagDataScriptableObject tagDataEnemy;
    [SerializeField] private TagDataScriptableObject tagDataInteractable;

    private void Awake()
    {
        characterFormsController = GetComponent<CharacterFormsController>();
        characterItemHolder = GetComponent<CharacterItemHolder>();
    }

    private void Start()
    {
        currentlyInteractable = new List<Interactable>();
        invulTimer = Time.time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (invulTimer > Time.time)
            return;

        if (collision.collider.CompareTag(tagDataEnemy.tagName) && collision.collider.GetComponent<CharacterFormsController>().currForm == Form.Crab && characterFormsController.currForm == Form.Destroyer)
        {
            return;
        }
        else if (collision.collider.CompareTag(tagDataEnemy.tagName) && collision.collider.GetComponent<CharacterFormsController>().currForm == Form.Crab)
        {
            Respawn();
        }
        else if (collision.collider.CompareTag(tagDataEnemy.tagName) && characterFormsController.currForm != collision.collider.GetComponent<CharacterFormsController>().currForm)
        {
            RespawnAsNewForm(collision.collider.GetComponent<CharacterFormsController>().currForm, collision.collider.transform.position);
            collision.collider.GetComponent<EnemyInteraction>().DestroyEnemy();
            invulTimer = Time.time + invulTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagDataInteractable.tagName) || collision.CompareTag(tagDataEnemy.tagName))
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
        characterItemHolder.DropItem();
        GameMangerRootMaster.instance.playerManager.DisableCharacterControls();
        GameObject deathInstance = Instantiate(deathPrefab, transform.position, Quaternion.identity);
        deathInstance.GetComponent<CharacterFormsController>().ChangeForm(characterFormsController.currForm);  // These were firing before Start() on deathInstance.  Weird.
        deathInstance.GetComponent<CharacterDeathController>().Die();
        riseAgainParticles.Play();
        GameMangerRootMaster.instance.audioManager.PlayAudio(soundDataPlayerDeath);
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
