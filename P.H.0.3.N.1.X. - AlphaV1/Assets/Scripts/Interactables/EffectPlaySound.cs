using UnityEngine;

public class EffectPlaySound : MonoBehaviour
{
    [SerializeField] private SoundData soundDataPickUpItem;

    public void PlaySound()
    {
        GameMangerRootMaster.instance.audioManager.PlayAudio(soundDataPickUpItem);
    }
}
