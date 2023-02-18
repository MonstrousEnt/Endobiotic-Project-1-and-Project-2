using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Form intialForm = Form.Manipulator;
    [SerializeField] private float aggroRadius = 5;

    private bool isAttacking = false;
    private Transform m_target = null;

    private CharacterFormsController characterFormController;
    private Rigidbody2D m_rigidbody2D;

    private void Awake()
    {
        characterFormController = GetComponent<CharacterFormsController>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        characterFormController.ChangeForm(intialForm);
        StartCoroutine(intelligence(aggroRadius, 0.5f));
    }

    private void Update()
    {
        m_rigidbody2D.velocity = Vector2.zero;

        if (!isAttacking)
        {
            return;
        }

        if (Vector3.Distance(transform.position, m_target.position) < 0.001f)
        {
            return;
        }

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, m_target.position, step);
    }

    public Form GetForm()
    {
        return intialForm;
    }

    private GameObject FindTargetsInRange(float range)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range);  // Layermask doesn't seem to work

        foreach(Collider2D hit in hits)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                return hit.gameObject;
            }
        }

        return null;
    }

    private void SetBehaviour(GameObject target)
    {
        if(target != null && target.TryGetComponent(out CharacterFormsController formController) && formController.currForm != characterFormController.currForm)
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

    private IEnumerator intelligence(float range, float updateSpeed)
    {
        while (true)
        {
            SetBehaviour(FindTargetsInRange(range));
            yield return new WaitForSeconds(updateSpeed);       // could cache this WaitForSeconds
        }
    }
}
