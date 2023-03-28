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
        //Initialize components 
        m_animator = GetComponentInChildren<Animator>();
    }
    #endregion

    #region C# Methods
    public void Die()
    {
        //Run the death animation when player die
        ChangeAnimationState(m_DEATH);
    }
    #endregion
}