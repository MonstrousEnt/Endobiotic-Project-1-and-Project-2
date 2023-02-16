using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool canMove = true;
    
    public void EnableCharacterControls()
    {
        canMove = true;
    }

    public void DisableCharacterControls()
    {
        canMove = false;
    }

    public bool CanMove()
    {
        return canMove;
    }
}
