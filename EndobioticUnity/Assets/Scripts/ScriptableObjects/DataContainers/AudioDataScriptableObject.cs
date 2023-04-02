/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 3, 2023
 * Last Updated: April 2, 2023
 * Description: This is the scriptable object data container class for audio data.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/Data Containers/Audio Data")]
public class AudioDataScriptableObject : ScriptableObject
{
    #region Class Variables 
    [SerializeField] private AudioClip m_clip;
    [SerializeField] private string m_audioGameObjectName;
    [SerializeField] private float m_volume;
    [SerializeField] private float m_pitch;
    [SerializeField] private bool m_loop;
    [SerializeField] private bool m_playOnAwake = false;

    private AudioSource m_source;
    #endregion

    #region Getters and Setters
    public AudioClip clip { get { return m_clip; } set { m_clip = value; } }
    public string audioGameObjectName { get { return m_audioGameObjectName; } set { m_audioGameObjectName = value; } }
    public float volume { get { return m_volume; } set { m_volume = value; } }
    public float pitch { get { return m_pitch; } set { m_pitch = value; } }
    public bool loop { get { return m_loop; } set { m_loop = value; } }
    public bool playOnAwake { get { return m_playOnAwake; } set { m_playOnAwake = value; } }
    public AudioSource source { get { return m_source; } set { m_source = value; } }
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        source = null;
    }
    #endregion
}