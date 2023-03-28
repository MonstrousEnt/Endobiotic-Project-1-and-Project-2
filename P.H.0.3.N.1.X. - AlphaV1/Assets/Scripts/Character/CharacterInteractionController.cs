using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterFormsController))]
public class CharacterInteractionController : MonoBehaviour
{
    #region Class Variables
    [Header("Prefabs")]
    [SerializeField] private GameObject deathPrefab;

    [Header("Special Effects")]
    [SerializeField] private ParticleSystem riseAgainParticles;

    [Header("Sounds")]
    [SerializeField] private UnityEvent soundEffectUnityEvent;

    [Header("InvulTimer")]
    [SerializeField] private float invulTime = 1f;
    private float invulTimer;

    [Header("Tags Scripbale Object")]
    [SerializeField] private TagDataScriptableObject tagDataEnemy;
    [SerializeField] private TagDataScriptableObject tagDataInteractable;

    [Header("Boolean Flag Scriptable Object - Player Manager")]
    [SerializeField] private BooleanFlagGlobalVariableScriptableObject m_booleanFlagGlobalVariablePlayerCanMove;

    //Components
    private CharacterFormsController characterFormsController;
    private CharacterItemHolder characterItemHolder;

    //Current Intractable
    private List<Interactable> currentlyInteractable;
    #endregion

    #region Unity Methods
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

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (invulTimer > Time.time) 
        {
            return;
        }

        if (collision2D.collider.CompareTag(tagDataEnemy.tagName) && collision2D.collider.GetComponent<CharacterFormsController>().currForm == Form.Crab && characterFormsController.currForm == Form.Destroyer) 
        {
            return;
        }
        else if (collision2D.collider.CompareTag(tagDataEnemy.tagName) && collision2D.collider.GetComponent<CharacterFormsController>().currForm == Form.Crab) 
        {
            respawnCrab();
        }
        //if the player collides with the enemy and is not the form of the enemy
        else if (collision2D.collider.CompareTag(tagDataEnemy.tagName) && characterFormsController.currForm != collision2D.collider.GetComponent<CharacterFormsController>().currForm)
        {
            respawnCharacter(collision2D);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag(tagDataInteractable.tagName) || collider2D.CompareTag(tagDataEnemy.tagName))
        {
            addIntractable(collider2D);
        }   
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        removeIntractable(collider2D);
    }
    #endregion



    #region Character Interaction Methods
    public void Interact()
    {
        if (currentlyInteractable.Count <= 0)
        {
            return;
        }

        foreach (Interactable interactable in currentlyInteractable)
        {
            interactable.Interact(characterFormsController.currForm);
        }
    }

    private void addIntractable(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Interactable interactable))
        {
            currentlyInteractable.Add(interactable);
        }
    }

    private void removeIntractable(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Interactable interactable))
        {
            currentlyInteractable.Remove(interactable);
        }
    }

    private void respawnCrab()
    {
        characterItemHolder.DropItem();

        // TODO set a respawn location or enable a variable for a designer
        Vector2 randomLocation = new Vector2(Random.Range(-4.0f, 4.0f), Random.Range(-2.0f, 2.0f));
        transform.position = new Vector3(randomLocation.x, randomLocation.y, 0);
    }

    private void respawnAsNewForm(Form newForm, Vector3 position)
    {
   
        characterItemHolder.DropItem();

        m_booleanFlagGlobalVariablePlayerCanMove.DisableBooleanFlag();

        GameObject deathInstance = Instantiate(deathPrefab, transform.position, Quaternion.identity);

        deathInstance.GetComponent<CharacterFormsController>().ChangeForm(characterFormsController.currForm);  // These were firing before Start() on deathInstance. Weird. 
        deathInstance.GetComponent<CharacterDeathController>().Die();

        riseAgainParticles.Play();

        characterFormsController.ChangeForm(newForm);

        transform.position = position;

        soundEffectUnityEvent?.Invoke();

        StartCoroutine(waitWhileDead(2));
    }

    private void respawnCharacter(Collision2D collision2D)
    {
        respawnAsNewForm(collision2D.collider.GetComponent<CharacterFormsController>().currForm, collision2D.collider.transform.position);

        collision2D.collider.GetComponent<EnemyInteraction>().DestroyEnemy();

        invulTimer = Time.time + invulTime;
    }

    private IEnumerator waitWhileDead(float duration)
    {
        yield return new WaitForSeconds(duration);

        m_booleanFlagGlobalVariablePlayerCanMove.EnableBoolFlag();
    }
    #endregion
}
