using UnityEngine;

[RequireComponent(typeof(CharacterFormsController))]
public class CharacterRespawnController : MonoBehaviour
{
    private CharacterFormsController characterFormsController;

    private void Start()
    {
        characterFormsController = GetComponent<CharacterFormsController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("collided");
            Respawn();
        }
    }

    private void Respawn()
    {
        characterFormsController.KillForm();

        Vector2 randomLocation = new Vector2(Random.Range(-4.0f, 4.0f), Random.Range(-2.0f, 2.0f));
        transform.position = new Vector3(randomLocation.x, randomLocation.y, 0);
    }
}
