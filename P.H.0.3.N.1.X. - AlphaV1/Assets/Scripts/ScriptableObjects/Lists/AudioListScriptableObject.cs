/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 5, 2023
 * Last Updated: Match 12, 2023
 * Description: This is the scriptable object list class for audio list.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioList", menuName = "Scriptable Objects/Lists/Audio List")]
public class AudioListScriptableObject : ScriptableObject
{
    #region Class Variables
    //List
    [SerializeField] private List<AudioDataScriptableObject> m_audioDatas = new List<AudioDataScriptableObject>();
    #endregion

    #region Getters and Setters
    public List<AudioDataScriptableObject> audioDatas { get { return m_audioDatas; } set { audioDatas = value; } }
    #endregion
}
