/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Ben Topple, James Dalziel, Daniel Cox
 * Created Date: February 13, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the class for player animations.
 * Notes:
 * Resources: 
 */

using UnityEngine;

public class PlayerControllerAnimations : BaseControllerAnimations
{
    #region Class Variables 
    //To Do create these animations states into Unity Scriptable Object data container
    [Header("Animation States - Destroyer")]
    [SerializeField] private string m_DEST_ATK_DOWN = "Atk_Down";
    [SerializeField] private string m_DEST_ATK_UP = "Atk_Up";
    [SerializeField] private string m_DEST_ATK_LEFT = "Atk_Left";
    [SerializeField] private string m_DEST_ATK_RIGHT = "Atk_Right";

    [Header("Animation States - Magnetic")]
    [SerializeField] private string m_MAGNET_PULL_DOWN = "Pull_Down";
    [SerializeField] private string m_MAGNET_PULL_UP = "Pull_Up";
    [SerializeField] private string m_MAGNET_PULL_LEFT = "Pull_Left";
    [SerializeField] private string m_MAGNET_PULL_RIGHT = "Pull_Right";

    [Header("Delay or Time")]
    private float m_requiredTime;
    #endregion

    #region Base Controller Animations Override Methods - Player Controller Animations
    protected override void ChangeAnimationState(string newAnimation)
    {

        if (m_requiredTime > Time.time)
        {
            return;
        }

        base.ChangeAnimationState(newAnimation);
    }
    #endregion

    #region Unity Methods
    private void Start()
    {
        m_requiredTime = Time.time;
    }
    #endregion

    #region Animation Methods
    public void DestroyerAttack()
    {
        switch (m_LastMoveDir)
        {            
            case MoveDirection.Up:
                ChangeAnimationState(m_DEST_ATK_UP);
                break;
            case MoveDirection.Down:
                ChangeAnimationState(m_DEST_ATK_DOWN);
                break;
            case MoveDirection.Left:
                ChangeAnimationState(m_DEST_ATK_LEFT);
                break;
            case MoveDirection.Right:
                ChangeAnimationState(m_DEST_ATK_RIGHT);
                break;
        }
        m_requiredTime = Time.time + 0.25f;
    }

    public void MagnetPull()
    { 
        switch (m_LastMoveDir)
        {
            case MoveDirection.Up:
                ChangeAnimationState(m_MAGNET_PULL_DOWN);
                break;
            case MoveDirection.Down:
                ChangeAnimationState(m_MAGNET_PULL_DOWN);
                break;
            case MoveDirection.Left:
                ChangeAnimationState(m_MAGNET_PULL_LEFT);
                break;
            case MoveDirection.Right:
                ChangeAnimationState(m_MAGNET_PULL_RIGHT);
                break;
        }        
    }
    #endregion
}
