using System.Collections;
using UnityEngine;

/// <summary>
/// This effect class is for disable a Collier 2D of any game object.
/// </summary>

public class EffectDisableCollider : MonoBehaviour
{
    #region Class Variables
    [Header("Delay")]
    [SerializeField] private float m_delay = 0;

    [Header("Collier 2D")]
    [SerializeField] private Collider2D m_collider;
    #endregion

    #region Disable Collier Methods
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
    #endregion
}
