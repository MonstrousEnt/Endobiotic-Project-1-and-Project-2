using System.Collections;
using UnityEngine;

public class GreenBlockObject : MonoBehaviour
{
    [SerializeField] private float m_timeUnderColliderRemoved = 0.35f;

    public void BreakBlock()
    {
        StartCoroutine(BreakBlockRoutine(m_timeUnderColliderRemoved));
    }

    private IEnumerator BreakBlockRoutine(float waitTime)
    {
        if (TryGetComponent(out Animator animator))
        {
            animator.Play("Green_Block_Destroyed");
        }

        yield return new WaitForSeconds(waitTime);

        if (TryGetComponent(out Collider2D collider))
        {
            collider.enabled = false;
        }
    }
}
