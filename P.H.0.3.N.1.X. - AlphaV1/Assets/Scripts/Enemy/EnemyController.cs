using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Class Variables
    [Header("Form")]
    [SerializeField] private Form m_intialForm = Form.Manipulator;

    [Header("AI")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float aggroRadius = 5;

    //Attack 
    private bool isAttacking = false;

    //Target
    private Transform m_target = null;
    private CharacterFormsController characterFormController;

    //Movement
    private Rigidbody2D m_rigidbody2D;
    private Vector3 preferredPosition;

    [Header("Tag")]
    [SerializeField] private TagDataScriptableObject m_tagDataPlayer;
    #endregion

    #region Getters and Setters
    public Form Form { get { return m_intialForm; } }

    private void SetBehaviour(GameObject target)
    {
        if (target != null && target.TryGetComponent(out CharacterFormsController formController) && formController.currForm != characterFormController.currForm)
        {
            m_target = target.transform;
            isAttacking = true;
        }
        else
        {
            m_target = null;
            isAttacking = false;
        }

    }
    #endregion

    #region Find Methods
    private GameObject FindTargetsInRange(float range)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range);

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
        characterFormController = GetComponent<CharacterFormsController>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        preferredPosition = transform.position;
    }

    private void Start()
    {
        characterFormController.ChangeForm(m_intialForm);
        StartCoroutine(intelligence(aggroRadius, 0.5f));
    }

    public void UpdatePreferredPosition(Vector3 position)
    {
        preferredPosition = position;
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
        float step = moveSpeed * Time.deltaTime;

        if (isAttacking)
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
            if (Vector3.Distance(transform.position, preferredPosition) < 0.001f)
            {
                return;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, preferredPosition, step);
            }
        }
    }

    private IEnumerator intelligence(float range, float updateSpeed)
    {
        while (true)
        {
            SetBehaviour(FindTargetsInRange(range));
            yield return new WaitForSeconds(updateSpeed);      
        }
    }
    #endregion
}
