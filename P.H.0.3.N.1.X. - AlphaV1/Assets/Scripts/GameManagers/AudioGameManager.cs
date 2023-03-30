/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 15, 2023
 * Last Updated: Match 30, 2023
 * Description: This is the game manager class for audio.
 * Notes:
 * Resources: 
 *	Unite 2016:  https://youtu.be/6vmRwLYWNRo
 *	How To Use Scriptable Objects in Unity: https://youtu.be/lJxy3oTZeCs
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGameManager : MonoBehaviour
{
    #region Class Variables 
    [Header("Audio List")]
	[SerializeField] private AudioListScriptableObject m_audioListSoundEffects;
	[SerializeField] private AudioListScriptableObject m_audioListSoundtracks;

	[Header("Game Objects")]
	[SerializeField] private GameObject m_soundEffectsGameObject;
	[SerializeField] private GameObject m_soundtrackGameObject;
    #endregion

    #region Getters and Setters
    private void setAudioScource(AudioDataScriptableObject a_audioData)
	{
		a_audioData.source.clip = a_audioData.clip;
		a_audioData.source.volume = a_audioData.volume;
		a_audioData.source.pitch = a_audioData.pitch;
		a_audioData.source.loop = a_audioData.loop;
		a_audioData.source.playOnAwake = a_audioData.playOnAwake;
	}
	#endregion

	#region Initialize Methods
	private void intializeGameObject(AudioDataScriptableObject a_audioData, GameObject a_parentGameObject)
	{
		GameObject l_audioGameObject = new GameObject(a_audioData.audioGameObjectName);
		l_audioGameObject.transform.parent = a_parentGameObject.transform;

		AudioSource l_audioSource = l_audioGameObject.AddComponent<AudioSource>();
		a_audioData.source = l_audioSource;
	}
	private void intializeGameObjects(AudioListScriptableObject a_audioList, GameObject a_parentGameObject)
	{
		for (int i = 0; i < a_audioList.audioDatas.Count; i++)
        {
			intializeGameObject(a_audioList.audioDatas[i], a_parentGameObject);
			setAudioScource(a_audioList.audioDatas[i]);
        }
	}
	#endregion

	#region Audio Game Events
	public void PlaySound(AudioDataScriptableObject a_audioData)
	{
		if (a_audioData.source != null)
		{
			a_audioData.source.Play();
		}
	}

	public void PlayRandomSound(AudioListScriptableObject a_audioList)
    {
		int randomIndex = Random.Range(1, a_audioList.audioDatas.Count - 1);
		PlaySound(a_audioList.audioDatas[randomIndex]);
    }

	public void StopSound(AudioDataScriptableObject a_audioData)
	{
		if (a_audioData.source != null)
		{
			a_audioData.source.Stop();
		}
	}

	public void DisableLoop(AudioDataScriptableObject a_audioData)
	{
		if (a_audioData.source != null)
        {
			a_audioData.loop = false;
			a_audioData.source.loop = false;
		}
	}

	public void EnableLoop(AudioDataScriptableObject a_audioData)
	{
		if (a_audioData.source != null)
        {
			a_audioData.loop = true;
			a_audioData.source.loop = true;
		}
	}
    #endregion

    #region Unity Methods
    private void Awake()
    {
		intializeGameObjects(m_audioListSoundEffects, m_soundEffectsGameObject);
		intializeGameObjects(m_audioListSoundtracks, m_soundtrackGameObject);
    }
    #endregion
}