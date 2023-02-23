using UnityEngine;
using UnityEngine.Events;

public class EnemyInteraction : MonoBehaviour
{
    // TODO this class is unfinished and unused

    private EnemyControllerAnimations enemyControllerAnimations;
    private CharacterFormsController characterFormsController;

    public UnityEvent<GameObject> deathEvent;

    private void Awake()
    {
        characterFormsController = GetComponent<CharacterFormsController>();
        deathEvent = new UnityEvent<GameObject>();
    }

    public void KillEnemy()
    {
        if (characterFormsController.currForm != Form.Crab)
            return;

        deathEvent?.Invoke(this.gameObject);

        Destroy(this.gameObject);
    }

    public void DestroyEnemy()
    {
        deathEvent?.Invoke(this.gameObject);

        Destroy(this.gameObject);
    }
}
