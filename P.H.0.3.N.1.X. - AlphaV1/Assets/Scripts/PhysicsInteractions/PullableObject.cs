using UnityEngine;

public class PullableObject : MonoBehaviour
{
    [SerializeField] private float magnetForceStrength;
    private Rigidbody2D rigidBody2D;
    private GameObject character;

    [SerializeField] private TagDataScriptableObject tagDataPlayer;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        character = GameObject.FindGameObjectWithTag(tagDataPlayer.tagName);
    }

    public void AddForce()
    {
        rigidBody2D.mass = 10;
        Vector3 forceDirection = (transform.position - character.transform.position).normalized;
        rigidBody2D.AddForce(forceDirection * -magnetForceStrength);
    }
}
