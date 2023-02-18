using UnityEngine;

public class DestroyerFormAttack : MonoBehaviour
{
    [SerializeField] PlayerControllerAnimations playerControllerAnimations;

    private void Update()
    {
        if (playerControllerAnimations == null)
            return;

        if (Input.GetKeyUp(KeyCode.Mouse1) || Input.GetButton("Fire1"))
        {
            playerControllerAnimations.DestroyerAttack();
        }
    }
}
