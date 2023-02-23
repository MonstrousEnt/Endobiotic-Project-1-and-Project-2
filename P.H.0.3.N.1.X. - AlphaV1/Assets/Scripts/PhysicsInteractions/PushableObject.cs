using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PushableObject : MonoBehaviour
{
    [SerializeField] private Form requiredForm;
    [SerializeField] private InteractableOjbects objectType;
    [SerializeField] private bool destroyOnceUsed;

    [SerializeField] private SoundData soundDataPush;

    private Rigidbody2D rigidBody2D;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.TryGetComponent(out TrapObject trapObject))
        {
            if (trapObject.GetObjectType() == objectType)
            {
                trapObject.Interact();

                if (destroyOnceUsed)
                {
                    Destroy(gameObject);
                }
            }
        }
        else if (collision.gameObject.TryGetComponent(out CharacterFormsController formController))
        {
            if (formController.currForm == requiredForm)
            {
                rigidBody2D.mass = 10;

                GameMangerRootMaster.instance.audioManager.PlayAudio(soundDataPush);
            }
            else
            {
                rigidBody2D.mass = float.MaxValue;
            }
        }
    }
}
