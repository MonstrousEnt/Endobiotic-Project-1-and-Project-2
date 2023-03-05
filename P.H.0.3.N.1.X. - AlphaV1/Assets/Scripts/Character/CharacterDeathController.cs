using UnityEngine;

public class CharacterDeathController : BaseControllerAnimations
{
    private string currentAnimaton;
    private const string DEATH = "death";

    private void Start()
    {
        m_animator = GetComponentInChildren<Animator>();
    }

    public void Die()
    {
        ChangeAnimationState(DEATH);
    }
}
