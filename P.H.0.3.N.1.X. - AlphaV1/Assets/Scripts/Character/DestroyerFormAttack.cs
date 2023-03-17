using UnityEngine;

public class DestroyerFormAttack : MonoBehaviour
{
    [SerializeField] PlayerControllerAnimations playerControllerAnimations;

    private void Update()
    {
        if (playerControllerAnimations == null)
            return;

        if (Input.GetButton("FormAction"))
        {
            playerControllerAnimations.DestroyerAttack();
        }
    }
}
