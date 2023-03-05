using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Class Variables 
    [Header("Audio List")]
	[SerializeField] private AudioListScriptableObject m_audioListSoundEffects;
	[SerializeField] private AudioListScriptableObject m_audioListSoundtracks;

	[Header("Game Objects")]
	[SerializeField] private GameObject SoundEffectsGameObject;
	[SerializeField] private GameObject SoundtrackGameObject;
    #endregion

    #region Getters and Setters
    private void setAudioScource(AudioDataScriptableObject audioData)
	{
		audioData.source.clip = audioData.clip;
		audioData.source.volume = audioData.volume;
		audioData.source.pitch = audioData.pitch;
	}
	#endregion

	#region Initialize Methods
	private void intializeGameObject(AudioDataScriptableObject audioData, GameObject parentGameObject)
	{
		GameObject audioGameObject = new GameObject(audioData.audioName);
		audioGameObject.transform.parent = parentGameObject.transform;
		AudioSource audioSource = audioGameObject.AddComponent<AudioSource>();
		audioData.source = audioSource;
	}
	private void intializeGameObjects(AudioListScriptableObject audioList, GameObject parentGameObject)
	{
		for (int i = 0; i < audioList.audioDatas.Count; i++)
        {
			intializeGameObject(audioList.audioDatas[i], parentGameObject);
			setAudioScource(audioList.audioDatas[i]);
        }
	}
	#endregion

	#region Audio Game Events
	public void PlaySound(AudioDataScriptableObject audioData)
	{
		if (audioData.source != null)
		{
			audioData.source.enabled = true;
			audioData.source.Play();
		}
	}

	public void StopSound(AudioDataScriptableObject audioData)
	{
		if (audioData.source != null)
		{
			audioData.source.Stop();
		}
	}

	public void DisableLoop(AudioDataScriptableObject audioData)
	{
		if (audioData.source != null)
        {
			audioData.loop = false;
			audioData.source.loop = false;
		}
	}

	public void EnableLoop(AudioDataScriptableObject audioData)
	{
		if (audioData.source != null)
        {
			audioData.loop = true;
			audioData.source.loop = true;
		}
	}
    #endregion

    #region Unity Methods
    private void Awake()
    {
		intializeGameObjects(m_audioListSoundEffects, SoundEffectsGameObject);
		intializeGameObjects(m_audioListSoundtracks, SoundtrackGameObject);
    }
    #endregion
}