using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    private EnemyControllerAnimations enemyControllerAnimations;
    private CharacterFormsController characterFormsController;

    private void Awake()
    {
        characterFormsController = GetComponent<CharacterFormsController>();
    }

    public void KillEnemy()
    {
        if (characterFormsController.currForm != Form.Enemy)
            return;

        Destroy(this.gameObject);
    }
}
