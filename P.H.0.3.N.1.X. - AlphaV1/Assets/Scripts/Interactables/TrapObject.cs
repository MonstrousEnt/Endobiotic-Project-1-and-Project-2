using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class TrapObject : MonoBehaviour
{
    [SerializeField] private InteractableOjbects objectType;
    [SerializeField] private Sprite hasActivatedSprite;

    private SpriteRenderer spriteRenderer;
    private Collider2D trapCollider;

    [SerializeField] private PiontData piontData;
    [SerializeField] private PointList pointList;
    [SerializeField] private PuzzlePointsList currPuzzlePointsList;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trapCollider = GetComponent<Collider2D>();
    }

    public void Interact()
    {
        pointList.AddToTheCollectPointsList(piontData, currPuzzlePointsList);

        spriteRenderer.sprite = hasActivatedSprite;
        trapCollider.enabled = false;
    }

    public InteractableOjbects GetObjectType()
    {
        return objectType;
    }
}
