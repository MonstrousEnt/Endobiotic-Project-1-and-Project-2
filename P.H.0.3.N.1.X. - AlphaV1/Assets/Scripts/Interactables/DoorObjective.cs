using UnityEngine;

public class DoorObjective : MonoBehaviour
{
   [SerializeField] private SoundData soundDataSolvePuzzle;

    public void DisableDoor()
    {
        GameMangerRootMaster.instance.audioManager.PlayAudio(soundDataSolvePuzzle);
        gameObject.SetActive(false);
    }
}
