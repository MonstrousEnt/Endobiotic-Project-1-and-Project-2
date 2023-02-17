using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Form form = Form.Manipulator;
    [SerializeField] private float aggroRadius = 5;

    private bool isAttacking = false;
    private Transform m_target = null;

    private CharacterFormsController characterFormController;

    private void Awake()
    {
        characterFormController = GetComponent<CharacterFormsController>();
    }

    private void Start()
    {
        characterFormController.ChangeForm(form);
        StartCoroutine(intelligence(aggroRadius, 0.5f));
    }

    private void Update()
    {
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
        return form;
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
        if(target != null)
        {
            if(target.TryGetComponent(out CharacterFormsController formController))
            {
                if(formController.currForm != form)
                {
                    m_target = target.transform;
                    isAttacking = true;
                }
            }
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
