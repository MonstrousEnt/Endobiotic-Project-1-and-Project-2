using System.Collections;
using UnityEngine;

/// <summary>
/// This utility class is for Destroy any game object after couple of seconds.
//// </summary>

public class DestroyAfterSeconds : MonoBehaviour
{
    #region Class Variables
    [Header("How long the game object last unlit it get destroy")]
    [SerializeField] private float m_duration;
    #endregion

    #region Unity Methods
    void Start()
    {
        StartCoroutine(destroyAfter(m_duration));
    }
    #endregion

    #region Destroy After Methods
    private IEnumerator destroyAfter(float duration)
    {
        //Wait for a certain amount of seconds 
        yield return new WaitForSeconds(duration);

        //Destroy the game object
        Destroy(this.gameObject);
    }
    #endregion
}
