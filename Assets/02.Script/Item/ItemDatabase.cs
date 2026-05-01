using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance { get; private set; }

    [SerializeField] private CharacterData[] characters;
    [SerializeField] private AmuletData[] amulets;
    [SerializeField] private FieldItemData[] fieldItems;
    [SerializeField] private StockItemData[] stockItems;

    private Dictionary<int, ItemData> _db = new();


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Load();
        DontDestroyOnLoad(gameObject);
    }
   

    private void Load()
    {
        foreach (var item in characters) _db[item.itemID] = item;
        foreach (var item in amulets) _db[item.itemID] = item;
        foreach (var item in fieldItems) _db[item.itemID] = item;
        foreach (var item in stockItems) _db[item.itemID] = item;
    }

    public ItemData GetItem(int id) => _db.TryGetValue(id, out var item) ? item : null;
    public CharacterData GetCharacter(int id) => GetItem(id) as CharacterData;
    public AmuletData GetAmulet(int id) => GetItem(id) as AmuletData;
    public FieldItemData GetFieldItem(int id) => GetItem(id) as FieldItemData;
    public StockItemData GetNormalItem(int id) => GetItem(id) as StockItemData;
}