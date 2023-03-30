/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 15, 2023
 * Last Updated: Match 29, 2023
 * Description: This effect class is for spawn any object.
 * Notes: 
 * Resources: 
 *  
 */


using UnityEngine;

public class EffectSpawnObject : MonoBehaviour
{
    #region Class Variables
    [Header("Components")]
    [SerializeField] private GameObject m_objectPrefab;
    [SerializeField] private Vector3 m_locationOffset = new Vector3(0, 0, 0);
    #endregion

    #region Spawn Object Methods
    public void SpawnObject()
    {
        Instantiate(m_objectPrefab, transform.position, Quaternion.identity, this.transform);
    }
    #endregion
}
