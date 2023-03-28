using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This effect class is for disable any game object.
/// </summary>

public class EffectDisableObject : MonoBehaviour
{
    #region Disable Game Object Methods
    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
    #endregion
}
