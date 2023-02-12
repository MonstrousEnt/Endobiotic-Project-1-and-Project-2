using UnityEngine;

[RequireComponent(typeof(CharacterFormsController))]
public class CharacterInteractionController : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            Respawn();
        else
            Interact(collision);
    }

    private void Respawn()
    {
        characterFormsController.KillForm();

        Vector2 randomLocation = new Vector2(Random.Range(-4.0f, 4.0f), Random.Range(-2.0f, 2.0f));
        transform.position = new Vector3(randomLocation.x, randomLocation.y, 0);
    }

    private void Interact(Collider2D collision)
    {
        collision.GetComponent<Interactable>().Interact(characterFormsController.currForm);
    }
}
