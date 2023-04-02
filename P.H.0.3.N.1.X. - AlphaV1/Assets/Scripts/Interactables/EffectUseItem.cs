/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 18, 2023
 * Last Updated: April 2, 2023
 * Description: This effect class is for using a item.
 * Notes: 
 * Resources: 
 *  
 */

using UnityEngine;

public class EffectUseItem : MonoBehaviour
{
    #region Class Variables
    [Header("Tag Scriptabe Object")]
    [SerializeField] private TagDataScriptableObject m_tagDataPlayer;
    #endregion

    #region Item Methods
    public void UseItem()
    {
        GameObject.FindGameObjectWithTag(m_tagDataPlayer.tagName).GetComponent<CharacterItemHolder>().UseItem();
    }
    #endregion
}
