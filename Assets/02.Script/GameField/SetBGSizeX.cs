using UnityEngine;

public class SetBgSizeX : MonoBehaviour
{
    private FieldCreator creator;
    private SpriteRenderer[] spriteRenderer;
    private Vector3 originTransform;

    private void Awake()
    {
        if (creator == null)
        {
            creator = FindAnyObjectByType<FieldCreator>();
        }
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        }
        originTransform = this.transform.position;
    }

    private void OnEnable()
    {
        creator.OnCreateField += SetSizeTile;
    }
    private void OnDisable()
    {
        creator.OnCreateField -= SetSizeTile;
    }

    private void SetSizeTile(int length)
    {
        int size = length / 2;

        this.transform.position = new Vector3(size, originTransform.y, originTransform.z);

        for (int i = 0; i < spriteRenderer.Length; i++)
        {
            float height = spriteRenderer[i].sprite.bounds.size.y;
            spriteRenderer[i].size = new Vector2(size, height);
        }
    }

}
