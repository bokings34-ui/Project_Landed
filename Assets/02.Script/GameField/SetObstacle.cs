using UnityEngine;

public class SetObstacle : MonoBehaviour
{
    private enum AlignDirection
    {
        Up,
        Center,
        Down
    }
    [SerializeField]
    private AlignDirection align;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private int obstacleLayer = 10;


    private void Awake()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        if (boxCollider == null)
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }

        if (this.gameObject.layer != obstacleLayer)
        {
            this.gameObject.layer = obstacleLayer;
        }
    }

    private void Start()
    {
        FitColliderToSpriteByAlign();
    }


    private void FitColliderToSpriteByAlign()
    {
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
        if (spriteSize != boxCollider.size) boxCollider.size = spriteSize;
        float positionY = spriteSize.y / 2;

        switch (align)
        {
            case AlignDirection.Up:
                spriteRenderer.transform.localPosition = new Vector3(0, -positionY, 0);
                boxCollider.offset = new Vector2(0, -positionY);
                break;
            case AlignDirection.Center:
                spriteRenderer.transform.localPosition = Vector3.zero;
                boxCollider.offset = Vector2.zero;
                break;
            case AlignDirection.Down:
                spriteRenderer.transform.localPosition = new Vector3(0, positionY, 0);
                boxCollider.offset = new Vector2(0, positionY);
                break;
        }

    }
}
