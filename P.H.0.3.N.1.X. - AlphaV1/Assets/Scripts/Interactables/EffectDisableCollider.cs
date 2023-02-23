using System.Collections;
using UnityEngine;

public class EffectDisableCollider : MonoBehaviour
{
    [SerializeField] private float m_delay = 0;
    [SerializeField] private Collider2D m_collider;

    public void DisableCollider()
    {
        if(m_collider != null)
        {
            StartCoroutine(DisableColliderAfterDelay(m_delay));
        }
    }

    private IEnumerator DisableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        m_collider.enabled = false;
    }
}
