using UnityEngine;

public class EffectPlayAnimation : MonoBehaviour
{
    [SerializeField] private string m_animationName = "";

    public void PlayAnimation()
    {
        if (TryGetComponent(out Animator animator))
        {
            animator.Play(m_animationName);
        }
    }
}
