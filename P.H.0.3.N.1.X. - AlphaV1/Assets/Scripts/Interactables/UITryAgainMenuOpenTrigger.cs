using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This trigger class is for open the try again UI Menu.
/// </summary>

public class UITryAgainMenuOpenTrigger : MonoBehaviour
{
    [Header("Void Game Event Scriptable Object - UI Manager")]
    [SerializeField] private VoidGameEventScriptableObject m_voidGameEventUIManagerEnableTryMenu;

    #region Unity Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_voidGameEventUIManagerEnableTryMenu.Raise();
    }
    #endregion
}
