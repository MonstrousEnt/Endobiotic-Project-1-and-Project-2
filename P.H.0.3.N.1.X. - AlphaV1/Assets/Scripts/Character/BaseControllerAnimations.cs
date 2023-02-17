using UnityEngine;

public class BaseControllerAnimations : MonoBehaviour
{
    protected Animator m_animator;

    public void SetAnimator(Animator newAnimator)
    {
        m_animator = newAnimator;
    }
}
