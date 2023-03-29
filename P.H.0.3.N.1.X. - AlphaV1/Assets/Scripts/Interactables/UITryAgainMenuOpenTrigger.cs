using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This trigger class is for open the try again UI Menu.
/// </summary>

public class UITryAgainMenuOpenTrigger : MonoBehaviour
{
    [Header("Unity Events")]
    [SerializeField] private UnityEvent m_enbaleTryAgainMenuUjnityEvent;

    #region Unity Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_enbaleTryAgainMenuUjnityEvent?.Invoke();
    }
    #endregion
}
