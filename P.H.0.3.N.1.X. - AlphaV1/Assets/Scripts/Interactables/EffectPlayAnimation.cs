using UnityEngine;

/// <summary>
/// This effect class is for play any animation.
/// </summary>

public class EffectPlayAnimation : MonoBehaviour
{
    #region Class Variables 
    [Header("Animation States")]
    [SerializeField] private string m_animationName = "";
    #endregion

    #region Animation Methods
    public void PlayAnimation()
    {
        if (TryGetComponent(out Animator animator))
        {
            animator.Play(m_animationName);
        }
    }
    #endregion
}
