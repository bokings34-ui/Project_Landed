using System.Collections.Generic;
using UnityEngine;

public static class ItemIDGenerator
{
    private static Dictionary<int,int> _counter = new Dictionary<int, int>();

    /// <summary>
    /// 대분류만 있고, 세부 분류 없음 / 캐릭터와 부적 전용
    /// </summary>
    /// <param name="catagory"></param>
    /// <returns></returns>
    public static int GenerateID(ItemCategory catagory)
    {
        return Generate((int)catagory,0);
    }

    /// <summary>
    /// 게임 필드에 존재하는 아이템 전용. 세부 분류는 기능별로 나뉨. (점수, 화폐, 회복, 버프 등)
    /// </summary>
    /// <param name="subCatagory"></param>
    /// <returns></returns>
    public static int GenerateID(FieldItemSubCategory subCatagory)
    {
        return Generate((int)ItemCategory.FieldItem, (int)subCatagory);
    }

    /// <summary>
    /// 인벤토리에 데이터로 존재하지만 오브젝트로는 구현되지 않는 아이템 전용. 세부 분류는 기능별로 나뉨. (재료, 티켓 등)
    /// </summary>
    /// <param name="subCatagory"></param>
    /// <returns></returns>
    public static int GenerateID(StockItemSubCategory subCatagory)
    {
        return Generate((int)ItemCategory.StockItem, (int)subCatagory);
    }

    /// <summary>
    /// 아이템 ID 코드 제작.
    /// 1-01-000
    /// </summary>
    /// <param name="catagory">아이템 대분류 // 캐릭터, 부적, 필드아이템, 일반 아이템</param>
    /// <param name="subCatagory">세부 분류. 기능별로 분류</param>
    /// <returns>6자리 숫자의 아이템 ID</returns>
    private static int Generate(int catagory, int subCatagory)
    {
        int catagoryCode = catagory * 100000 + subCatagory*1000;

        if (!_counter.ContainsKey(catagoryCode))
        {
            _counter[catagoryCode] = 1;
        }
        else
        {
            _counter[catagoryCode]++;
        }

        if(_counter[catagoryCode] > 999)
        {
            Debug.LogError($"ItemID 초과: {catagoryCode}");
            return -1;
        }

        int itemIdCode = catagoryCode + _counter[catagoryCode];

        return itemIdCode;
    }
}
