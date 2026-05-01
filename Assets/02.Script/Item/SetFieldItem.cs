using UnityEngine;

public class SetFieldItem : MonoBehaviour
{
    [SerializeField] private FieldItemData data; // 에셋 드래그로 연결
    private SpriteRenderer spriteRenderer;
    //[SerializeField]
    private int itemId;
    private BoxCollider2D boxCollider;
    private int itemLayer = 11;
    public int ItemId => itemId;


    private void Awake()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (boxCollider == null)
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }

        if (gameObject.layer != itemLayer)
        {
            this.gameObject.layer = itemLayer;
        }

    }

    private void Start()
    {
        ApplyData();
        FitColliderToSprite();

    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (!target.CompareTag("Player")) return;
        Destroy(gameObject);
    }

    private void ApplyData()
    {
        if (data == null)
        {
            Debug.LogWarning("FieldItemData 가 없습니다!");
            return;
        }
        itemId = data.itemID;
        spriteRenderer.sprite = data.icon;
    }

    private void FitColliderToSprite()
    {
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
        if (spriteSize != boxCollider.size) boxCollider.size = spriteSize;

        boxCollider.offset = Vector2.zero;
    }
}