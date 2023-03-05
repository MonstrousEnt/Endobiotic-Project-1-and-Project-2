using UnityEngine;

public class EffectAudioData : MonoBehaviour
{
    [SerializeField] private AudioDataScriptableObject audioData;

    public void PlaySound()
    {
        audioData.PlaySound();
    }

    public void StopSound()
    {
        audioData.StopSound();
    }
}
