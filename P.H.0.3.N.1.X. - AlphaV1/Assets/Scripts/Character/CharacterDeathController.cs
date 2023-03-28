using UnityEngine;

public class CharacterDeathController : BaseControllerAnimations
{
    #region Class Variables
    //player Death animation
    private const string m_DEATH = "death";
    #endregion

    #region Unity Methods
    private void Start()
    {
        m_animator = GetComponentInChildren<Animator>();
    }
    #endregion

    #region Death Animations
    public void Die()
    {
        ChangeAnimationState(m_DEATH);
    }
    #endregion
}