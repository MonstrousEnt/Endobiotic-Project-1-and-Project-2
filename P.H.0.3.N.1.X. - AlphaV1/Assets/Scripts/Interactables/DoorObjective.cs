using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class DoorObjective : MonoBehaviour
{
    [SerializeField] private Sprite doorOpen;

    private SpriteRenderer m_spriteRenderer;
    private Collider2D m_collider;

    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_collider = GetComponent<Collider2D>();
    }

    public void OpenDoor()
    {
        m_spriteRenderer.sprite = doorOpen;
        m_collider.enabled = false;
    }
}
