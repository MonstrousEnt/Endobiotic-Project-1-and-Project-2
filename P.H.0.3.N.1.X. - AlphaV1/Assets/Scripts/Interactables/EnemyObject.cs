using UnityEngine;
using UnityEngine.Events;

public class EnemyObject : MonoBehaviour
{
    private EnemyControllerAnimations enemyControllerAnimations;
    private CharacterFormsController characterFormsController;

    public UnityEvent<Form, int> deathEvent;

    private void Awake()
    {
        characterFormsController = GetComponent<CharacterFormsController>();
        deathEvent = new UnityEvent<Form, int>();
    }

    public void KillEnemy()
    {
        if (characterFormsController.currForm != Form.Enemy)
            return;

        deathEvent?.Invoke(characterFormsController.currForm, -1);

        Destroy(this.gameObject);
    }

    public void DestroyEnemy()
    {
        deathEvent?.Invoke(characterFormsController.currForm, -1);

        Destroy(this.gameObject);
    }
}
