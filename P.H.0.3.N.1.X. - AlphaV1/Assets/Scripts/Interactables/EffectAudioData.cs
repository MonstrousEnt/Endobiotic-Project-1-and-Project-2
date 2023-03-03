using UnityEngine;

public class EffectAudioData : MonoBehaviour
{
    [SerializeField] private AudioDataScriptableObject audioData;
    [SerializeField] private AudioSource audioSource;

    public void PlaySound()
    {
        audioData.PlaySound(audioSource);
    }

    public void StopSound()
    {
        audioData.StopSound(audioSource);
    }
}
