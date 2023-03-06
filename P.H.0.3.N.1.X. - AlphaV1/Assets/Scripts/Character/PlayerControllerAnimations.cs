using UnityEngine;

public class PlayerControllerAnimations : BaseControllerAnimations
{
    #region Class Variables
    //To Do create these animations states into Unity Scriptable Object data container
    [Header("Animation States - Destroyer")]
    [SerializeField] private const string m_DEST_ATK_DOWN = "Atk_Down";
    [SerializeField] private const string m_DEST_ATK_UP = "Atk_Up";
    [SerializeField] private const string m_DEST_ATK_LEFT = "Atk_Left";
    [SerializeField] private const string m_DEST_ATK_RIGHT = "Atk_Right";

    [Header("Animation States - Magnetic")]
    [SerializeField] private const string m_MAGNET_PULL_DOWN = "Pull_Down";
    [SerializeField] private const string m_MAGNET_PULL_UP = "Pull_Up";
    [SerializeField] private const string m_MAGNET_PULL_LEFT = "Pull_Left";
    [SerializeField] private const string m_MAGNET_PULL_RIGHT = "Pull_Right";

    [Header("Delay or Time")]
    private float m_requiredTime;
    #endregion

    #region Override Methods
    protected override void ChangeAnimationState(string newAnimation)
    {
        //check to see if the delay is in effect
        if (m_requiredTime > Time.time)
            return;

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

    /// <summary>
    /// Destroyer Attack animation.
    /// </summary>
    public void DestroyerAttack()
    {
        switch (m_LastMoveDir)
        {            
            case m_moveDir.up:
                ChangeAnimationState(m_DEST_ATK_UP);
                break;
            case m_moveDir.down:
                ChangeAnimationState(m_DEST_ATK_DOWN);
                break;
            case m_moveDir.left:
                ChangeAnimationState(m_DEST_ATK_LEFT);
                break;
            case m_moveDir.right:
                ChangeAnimationState(m_DEST_ATK_RIGHT);
                break;
        }
        m_requiredTime = Time.time + 0.25f;
    }

    /// <summary>
    /// Magnet Pull Animation.
    /// </summary>
    public void MagnetPull()
    { 
        switch (m_LastMoveDir)
        {
            case m_moveDir.up:
                ChangeAnimationState(m_MAGNET_PULL_DOWN);
                break;
            case m_moveDir.down:
                ChangeAnimationState(m_MAGNET_PULL_DOWN);
                break;
            case m_moveDir.left:
                ChangeAnimationState(m_MAGNET_PULL_LEFT);
                break;
            case m_moveDir.right:
                ChangeAnimationState(m_MAGNET_PULL_RIGHT);
                break;
        }        
    }
    #endregion

}
