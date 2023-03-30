/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 13, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the character interaction controller for the player.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterFormsController))]
public class CharacterInteractionController : MonoBehaviour
{
    #region Class Variables
    [Header("Prefabs")]
    [SerializeField] private GameObject m_deathPrefab;

    [Header("Special Effects")]
    [SerializeField] private ParticleSystem m_riseAgainParticles;

    [Header("Sounds")]
    [SerializeField] private UnityEvent m_soundEffectUnityEvent;

    [Header("Invulnerable Timer")]
    [SerializeField] private float m_invulnerableTimeSF = 1f;

    [Header("Tags Scripbale Object")]
    [SerializeField] private TagDataScriptableObject m_tagDataEnemy;
    [SerializeField] private TagDataScriptableObject m_tagDataInteractable;

    [Header("Boolean Flag Scriptable Object - Player Manager")]
    [SerializeField] private BooleanFlagGlobalVariableScriptableObject m_booleanFlagGlobalVariablePlayerCanMove;

    //Components
    private CharacterFormsController m_characterFormsController;
    private CharacterItemHolder m_characterItemHolder;

    //Current Intractable
    private List<Interactable> m_currentlyInteractable;

    //Invulnerable Timer
    private float m_invulnerableTimer;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        m_characterFormsController = GetComponent<CharacterFormsController>();
        m_characterItemHolder = GetComponent<CharacterItemHolder>();
    }

    private void Start()
    {
        m_currentlyInteractable = new List<Interactable>();

        m_invulnerableTimer = Time.time;
    }

    private void OnCollisionEnter2D(Collision2D a_collision2D)
    {
        if (m_invulnerableTimer > Time.time) 
        {
            return;
        }

        if (a_collision2D.collider.CompareTag(m_tagDataEnemy.tagName) && a_collision2D.collider.GetComponent<CharacterFormsController>().currForm == Form.Crab && m_characterFormsController.currForm == Form.Destroyer) 
        {
            return;
        }
        else if (a_collision2D.collider.CompareTag(m_tagDataEnemy.tagName) && a_collision2D.collider.GetComponent<CharacterFormsController>().currForm == Form.Crab) 
        {
            respawnCrab();
        }
        else if (a_collision2D.collider.CompareTag(m_tagDataEnemy.tagName) && m_characterFormsController.currForm != a_collision2D.collider.GetComponent<CharacterFormsController>().currForm)
        {
            respawnCharacter(a_collision2D);
        }
    }

    private void OnTriggerEnter2D(Collider2D a_collider2D)
    {
        if (a_collider2D.CompareTag(m_tagDataInteractable.tagName) || a_collider2D.CompareTag(m_tagDataEnemy.tagName))
        {
            addIntractable(a_collider2D);
        }   
    }

    private void OnTriggerExit2D(Collider2D a_collider2D)
    {
        removeIntractable(a_collider2D);
    }
    #endregion

    #region Character Interaction Methods
    public void Interact()
    {
        if (m_currentlyInteractable.Count <= 0)
        {
            return;
        }

        foreach (Interactable interactable in m_currentlyInteractable)
        {
            interactable.Interact(m_characterFormsController.currForm);
        }
    }

    private void addIntractable(Collider2D a_collider2D)
    {
        if (a_collider2D.TryGetComponent(out Interactable a_interactable))
        {
            m_currentlyInteractable.Add(a_interactable);
        }
    }

    private void removeIntractable(Collider2D a_collider2D)
    {
        if (a_collider2D.TryGetComponent(out Interactable a_interactable))
        {
            m_currentlyInteractable.Remove(a_interactable);
        }
    }

    private void respawnCrab()
    {
        m_characterItemHolder.DropItem();

        // TODO set a respawn location or enable a variable for a designer
        Vector2 randomLocation = new Vector2(Random.Range(-4.0f, 4.0f), Random.Range(-2.0f, 2.0f));
        transform.position = new Vector3(randomLocation.x, randomLocation.y, 0);
    }

    private void respawnAsNewForm(Form a_newForm, Vector3 a_position)
    {
   
        m_characterItemHolder.DropItem();

        m_booleanFlagGlobalVariablePlayerCanMove.DisableBooleanFlag();

        GameObject deathInstance = Instantiate(m_deathPrefab, transform.position, Quaternion.identity);

        deathInstance.GetComponent<CharacterFormsController>().ChangeForm(m_characterFormsController.currForm);  // These were firing before Start() on deathInstance. Weird. 
        deathInstance.GetComponent<CharacterDeathController>().Die();

        m_riseAgainParticles.Play();

        m_characterFormsController.ChangeForm(a_newForm);

        transform.position = a_position;

        m_soundEffectUnityEvent?.Invoke();

        StartCoroutine(waitWhileDead(2));
    }

    private void respawnCharacter(Collision2D a_collision2D)
    {
        respawnAsNewForm(a_collision2D.collider.GetComponent<CharacterFormsController>().currForm, a_collision2D.collider.transform.position);

        a_collision2D.collider.GetComponent<EnemyInteraction>().DestroyEnemy();

        m_invulnerableTimer = Time.time + m_invulnerableTimeSF;
    }

    private IEnumerator waitWhileDead(float a_duration)
    {
        yield return new WaitForSeconds(a_duration);

        m_booleanFlagGlobalVariablePlayerCanMove.EnableBoolFlag();
    }
    #endregion
}
