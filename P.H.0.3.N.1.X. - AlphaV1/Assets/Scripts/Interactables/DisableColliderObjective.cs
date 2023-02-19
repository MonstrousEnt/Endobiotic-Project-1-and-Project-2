using UnityEngine;

public class DisableColliderObjective : MonoBehaviour
{
    [SerializeField] private Collider2D m_collider;

    public void DisableCollider()
    {
        if(m_collider != null)
        {
            m_collider.enabled = false;
        }
    }
}
