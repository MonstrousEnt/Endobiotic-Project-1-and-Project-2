using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EffectChangeSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite defaultState;
    [SerializeField] private Sprite newState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = defaultState;
    }

    public void ChangeSprite()
    {
        spriteRenderer.sprite = newState;
    }
}
