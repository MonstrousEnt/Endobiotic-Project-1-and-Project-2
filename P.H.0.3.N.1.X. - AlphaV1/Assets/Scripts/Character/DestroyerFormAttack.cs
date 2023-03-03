using UnityEngine;

public class DestroyerFormAttack : MonoBehaviour
{
    [SerializeField] PlayerControllerAnimations playerControllerAnimations;

    //[SerializeField] private SoundData soundDataPlayerAttack; 

    private void Update()
    {
        if (playerControllerAnimations == null)
            return;

        if (Input.GetButton("FormAction"))
        {
            playerControllerAnimations.DestroyerAttack();

            //GameMangerRootMaster.instance.audioManager.PlayAudio(soundDataPlayerAttack);
        }
    }
}
