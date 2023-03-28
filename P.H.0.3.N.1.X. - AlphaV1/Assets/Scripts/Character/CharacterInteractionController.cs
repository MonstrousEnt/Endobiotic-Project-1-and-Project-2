using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterFormsController))]
public class CharacterInteractionController : MonoBehaviour
{
    #region Class Variables
    //Components
    private CharacterFormsController characterFormsController;
    private CharacterItemHolder characterItemHolder;

    //List of Intractable
    private List<Interactable> currentlyInteractable;

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
    #endregion

    #region Unity Methods
    private void Awake()
    {
        //initialize components 
        characterFormsController = GetComponent<CharacterFormsController>();
        characterItemHolder = GetComponent<CharacterItemHolder>();
    }

    private void Start()
    {
        //initialize the list
        currentlyInteractable = new List<Interactable>();

        //set up the timer
        invulTimer = Time.time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (invulTimer > Time.time) 
        {
            return;
        }

        if (collision.collider.CompareTag(tagDataEnemy.tagName) && collision.collider.GetComponent<CharacterFormsController>().currForm == Form.Crab && characterFormsController.currForm == Form.Destroyer) //Note: what is crab form
        {
            return;
        }
        else if (collision.collider.CompareTag(tagDataEnemy.tagName) && collision.collider.GetComponent<CharacterFormsController>().currForm == Form.Crab) //Note: what is crab form
        {
            Respawn();
        }
        //if the player collides with the enemy and is not the form of the enemy
        else if (collision.collider.CompareTag(tagDataEnemy.tagName) && characterFormsController.currForm != collision.collider.GetComponent<CharacterFormsController>().currForm)
        {
            //Respawn the player as a new form
            RespawnAsNewForm(collision.collider.GetComponent<CharacterFormsController>().currForm, collision.collider.transform.position);

            //Destroy the enemy
            collision.collider.GetComponent<EnemyInteraction>().DestroyEnemy();

            invulTimer = Time.time + invulTime; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the object Colliers with intractable or enemy
        if (collision.CompareTag(tagDataInteractable.tagName) || collision.CompareTag(tagDataEnemy.tagName))
        {
            //Add the intractable 
            if (collision.TryGetComponent(out Interactable interactable))
            {
                currentlyInteractable.Add(interactable);
            }
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Remove the intractable 
        if (collision.TryGetComponent(out Interactable interactable))
        {
            currentlyInteractable.Remove(interactable);
        }
    }
    #endregion

    #region C# Methods
    public void Interact()
    {
        //if there is nothing to interact with, then exit out of the program
        if (currentlyInteractable.Count <= 0)
        {
            return;
        }

        //if there is a interaction, then interact with the block
        foreach (Interactable interactable in currentlyInteractable)
        {
            interactable.Interact(characterFormsController.currForm);
        }
    }

    private void Respawn()
    {
        //Drop the item - for Battery Form
        characterItemHolder.DropItem();

        // TODO set a respawn location or enable a variable for a designer
        Vector2 randomLocation = new Vector2(Random.Range(-4.0f, 4.0f), Random.Range(-2.0f, 2.0f));
        transform.position = new Vector3(randomLocation.x, randomLocation.y, 0);
    }

    private void RespawnAsNewForm(Form newForm, Vector3 position)
    {
        //Drop the item - for Battery Form
        characterItemHolder.DropItem();

        //Disable player movement
        m_booleanFlagGlobalVariablePlayerCanMove.DisableBooleanFlag();

        //span player death prefab
        GameObject deathInstance = Instantiate(deathPrefab, transform.position, Quaternion.identity);

        //change to default form 
        deathInstance.GetComponent<CharacterFormsController>().ChangeForm(characterFormsController.currForm);  // These were firing before Start() on deathInstance. Weird. 

        //run the player death animation 
        deathInstance.GetComponent<CharacterDeathController>().Die();

        //Run special effect for transform animation
        riseAgainParticles.Play();

        //change form to what the enemy was 
        characterFormsController.ChangeForm(newForm);

        //repswan the player at the same position
        transform.position = position;

        //player the spawn sound
        soundEffectUnityEvent.Invoke();

        //wait for 2 seconds
        StartCoroutine(WaitWhileDead(2));
    }

    /// <summary>
    /// Wait for a certain amount of seconds then re-enable the player controls for movement.
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    private IEnumerator WaitWhileDead(float duration)
    {
        yield return new WaitForSeconds(duration);

        m_booleanFlagGlobalVariablePlayerCanMove.EnableBoolFlag();
    }
    #endregion
}
