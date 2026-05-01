using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public int itemID;
    public string itemName;
    public Sprite icon;
    [TextArea] public string description;

    public ItemCategory itemCategory;
    public FieldItemSubCategory fieldItemCategory;
    public StockItemSubCategory stockItemCategory;

    [ContextMenu("ID 자동 발급")]
    private void AssignID()
    {
        if (itemCategory == ItemCategory.FieldItem)
        {
            itemID = ItemIDGenerator.GenerateID(fieldItemCategory);
        }
        else if (itemCategory == ItemCategory.StockItem)
        {
            itemID = ItemIDGenerator.GenerateID(stockItemCategory);
        }
        else
        {
            // 중분류가 없는 캐릭터 & 부적 전용
            itemID = ItemIDGenerator.GenerateID(itemCategory);
        }

        Debug.Log($"[{itemName}] 발급된 ID : {itemID}");

#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}