using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PushableObject : MonoBehaviour
{
    [Header("Form")]
    [SerializeField] private Form requiredForm;

    [Header("Intractable")]
    [SerializeField] private InteractableOjbects objectType;

    [Header("Pit Trap Data")]
    [SerializeField] private bool destroyOnceUsed;

    [Header("Unity Events")]
    [SerializeField] private UnityEvent soundEffectUnityEvent;

    //Components
    private Rigidbody2D rigidBody2D;

    #region Unity Methods
    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Pit Trap
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

        //Movement the block
        else if (collision.gameObject.TryGetComponent(out CharacterFormsController formController))
        {
            if (formController.currForm == requiredForm)
            {
                rigidBody2D.mass = 10;

                soundEffectUnityEvent.Invoke();
            }
            else
            {
                rigidBody2D.mass = float.MaxValue;
            }
        }
    }
    #endregion
}
