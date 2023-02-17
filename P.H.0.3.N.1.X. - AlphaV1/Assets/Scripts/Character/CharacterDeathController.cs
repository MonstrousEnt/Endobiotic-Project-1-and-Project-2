using UnityEngine;

public class CharacterDeathController : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Die();
    }

    private void Die()
    {
        // play the death animation
        animator.SetTrigger("die");
        // play the death VFX
    }
}
