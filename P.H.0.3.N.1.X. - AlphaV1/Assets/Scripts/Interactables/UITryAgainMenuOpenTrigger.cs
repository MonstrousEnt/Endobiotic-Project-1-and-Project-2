using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITryAgainMenuOpenTrigger : MonoBehaviour
{
    [SerializeField] private VoidGameEventScriptableObject m_voidGameEventUIManagerEnableTryMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_voidGameEventUIManagerEnableTryMenu.Raise();
    }
}
