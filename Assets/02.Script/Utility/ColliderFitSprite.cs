using UnityEngine;

public class ColliderFitSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        if(spriteRenderer == null) spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if(boxCollider == null) boxCollider = GetComponentInChildren<BoxCollider2D>();

        FitColliderToSprite(spriteRenderer, boxCollider);
    }


    [ContextMenu("Fit Collider To Sprite")]
    private void FitColliderToSprite(SpriteRenderer spriteRenderer, BoxCollider2D boxCollider)
    {
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
        Vector2 spriteScale = spriteRenderer.transform.localScale;
        Vector2 setSize = new Vector2(spriteSize.x * spriteScale.x, spriteSize.y * spriteScale.y);

        boxCollider.size = setSize;           // ? 콜라이더 크기를 스프라이트에 맞춤
        boxCollider.offset = Vector2.zero;        // 중심 맞춤
    }
}