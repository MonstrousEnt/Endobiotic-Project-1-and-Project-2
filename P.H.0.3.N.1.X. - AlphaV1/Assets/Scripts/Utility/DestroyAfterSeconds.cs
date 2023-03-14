using System.Collections;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    #region Class Variables
    [Header("How long the game object last unlit it get destroy")]
    [SerializeField] private float m_duration;
    #endregion

    #region Unity Methods
    void Start()
    {
        //run the Destroy After IEnumerator 
        StartCoroutine(DestroyAfter(m_duration));
    }
    #endregion

    #region C# Methods
    /// <summary>
    /// Destroy the game object after a certain amount of seconds.
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    IEnumerator DestroyAfter(float duration)
    {
        //Wait for a certain amount of seconds 
        yield return new WaitForSeconds(duration);

        //Destroy the game object
        Destroy(this.gameObject);
    }
    #endregion
}
