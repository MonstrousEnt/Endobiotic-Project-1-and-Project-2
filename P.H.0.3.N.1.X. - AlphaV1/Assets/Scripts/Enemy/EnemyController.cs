/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 15, 2023
 * Last Updated: Match 30, 2023
 * Description: This is the class for controlling the enemy.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Class Variables
    [Header("Form")]
    [SerializeField] private Form m_intialForm = Form.Manipulator;

    [Header("AI")]
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_aggroRadius;

    [Header("Tag")]
    [SerializeField] private TagDataScriptableObject m_tagDataPlayer;

    //Attack 
    private bool m_isAttacking = false;

    //Target
    private Transform m_target = null;
    private CharacterFormsController m_characterFormController;

    //Movement
    private Rigidbody2D m_rigidbody2D;
    private Vector3 m_preferredPosition;
    #endregion

    #region Getters and Setters
    public Form Form { get { return m_intialForm; } }

    private void SetBehaviour(GameObject a_target)
    {
        if (a_target != null && a_target.TryGetComponent(out CharacterFormsController a_formController) && a_formController.currForm != m_characterFormController.currForm)
        {
            m_target = a_target.transform;
            m_isAttacking = true;
        }
        else
        {
            m_target = null;
            m_isAttacking = false;
        }

    }
    #endregion

    #region Find Methods
    private GameObject FindTargetsInRange(float a_range)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, a_range);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.CompareTag(m_tagDataPlayer.tagName))
            {
                return hit.gameObject;
            }
        }

        return null;
    }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        m_characterFormController = GetComponent<CharacterFormsController>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_preferredPosition = transform.position;
    }

    private void Start()
    {
        m_characterFormController.ChangeForm(m_intialForm);
        StartCoroutine(intelligence(m_aggroRadius, 0.5f));
    }

    public void UpdatePreferredPosition(Vector3 a_position)
    {
        m_preferredPosition = a_position;
    }

    private void Update()
    {
        move();
    }
    #endregion

    #region AI Methods
    private void move()
    {
        m_rigidbody2D.velocity = Vector2.zero;
        float step = m_moveSpeed * Time.deltaTime;

        if (m_isAttacking)
        {
            if (Vector3.Distance(transform.position, m_target.position) < 0.001f)
            {
                return;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, m_target.position, step);
            }

        }
        else
        {
            if (Vector3.Distance(transform.position, m_preferredPosition) < 0.001f)
            {
                return;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, m_preferredPosition, step);
            }
        }
    }

    private IEnumerator intelligence(float a_range, float a_updateSpeed)
    {
        while (true)
        {
            SetBehaviour(FindTargetsInRange(a_range));
            yield return new WaitForSeconds(a_updateSpeed);      
        }
    }
    #endregion
}
