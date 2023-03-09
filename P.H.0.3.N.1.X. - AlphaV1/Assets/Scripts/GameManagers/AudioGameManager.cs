using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGameManager : MonoBehaviour
{
    [Header("Audio List")]
	[SerializeField] private AudioListScriptableObject m_audioListSoundEffects;
	[SerializeField] private AudioListScriptableObject m_audioListSoundtracks;

	[Header("Game Objects")]
	[SerializeField] private GameObject SoundEffectsGameObject;
	[SerializeField] private GameObject SoundtrackGameObject;

    #region Getters and Setters
    private void setAudioScource(AudioDataScriptableObject audioData)
	{
		audioData.source.clip = audioData.clip;
		audioData.source.volume = audioData.volume;
		audioData.source.pitch = audioData.pitch;
		audioData.source.loop = audioData.loop;
		audioData.source.playOnAwake = audioData.playOnAwake;
	}
	#endregion

	#region Initialize Methods
	private void intializeGameObject(AudioDataScriptableObject audioData, GameObject parentGameObject)
	{
		GameObject audioGameObject = new GameObject(audioData.audioGameObjectName);
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
			audioData.source.Play();
		}
	}

	public void PlayRandomSound(AudioListScriptableObject audioList)
    {
		int randomIndex = Random.Range(1, audioList.audioDatas.Count - 1);
		PlaySound(audioList.audioDatas[randomIndex]);
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